#include "shader.h"
#include <iostream>
#include <fstream>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <cmath>
#include <chrono>
#include <ctime>  



static std::string LoadShader(const std::string& fileName);
static void CheckShaderError(GLuint shader, GLuint flag, bool isProgram, const std::string& errorMessage);
static GLuint CreateShader(const std::string& text, GLenum shaderType);

Shader::Shader(const std::string& fileName, bool firstShader) {

    m_shaders[0] = CreateShader(LoadShader(fileName + ".vs"), GL_VERTEX_SHADER);
    m_shaders[1] = CreateShader(LoadShader(fileName + ".fs"), GL_FRAGMENT_SHADER);
  

    m_program[0] = glCreateProgram();


    glAttachShader(m_program[0], m_shaders[0]);
    glAttachShader(m_program[0], m_shaders[1]);


    glLinkProgram(m_program[0]);
    CheckShaderError(m_program[0], GL_LINK_STATUS, true, "error: link phase fails");

    glValidateProgram(m_program[0]);
    CheckShaderError(m_program[0], GL_VALIDATE_STATUS, true, "error: program is invalid");


}


Shader::~Shader() {
    for(unsigned int i = 0; i < NUM_SHADERS; i++) {
        glDetachShader(m_program[0], m_shaders[i]);
        glDeleteShader(m_shaders[i]);
    }

	glDeleteProgram(m_program[0]);

}



void Shader::useProgram(int index) {
    glUseProgram(m_program[index]);

};


void Shader::Draw() {


static const GLfloat g_vertex_buffer_data[] = {
   -1.0f, -1.0f, 0.0f,
   0.0f, 1.0f, 0.0f,
    1.0f,  -1.0f, 0.0f,
    0.5f,  -0.5f, 0.0f,
};

unsigned int indices[] = {  // note that we start from 0!
    0, 1, 2   // first triangle
  //  2, 0, 3    // second triangle
}; 

GLuint VertexArrayID;
glGenVertexArrays(1, &VertexArrayID);
glBindVertexArray(VertexArrayID);


 
GLuint vertexbuffer;
glGenBuffers(1, &vertexbuffer);
glBindBuffer(GL_ARRAY_BUFFER, vertexbuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(g_vertex_buffer_data), g_vertex_buffer_data, GL_STATIC_DRAW);



glEnableVertexAttribArray(0);
glBindBuffer(GL_ARRAY_BUFFER, vertexbuffer);
glVertexAttribPointer(
   0,                  // Атрибут 0. Подробнее об этом будет рассказано в части, посвященной шейдерам.
   3,                  // Размер
   GL_FLOAT,           // Тип
   GL_FALSE,           // Указывает, что значения не нормализованы
   0,                  // Шаг
   (void*)0            // Смещение массива в буфере
);


unsigned int EBO;
glGenBuffers(1, &EBO);
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);
glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, 0);

glDisableVertexAttribArray(0);

    
}

std::string LoadShader(const std::string& fileName) {
    std::ifstream file;
    file.open((fileName).c_str());

    std::string output;
    std::string line;

    if(file.is_open()) {
        while(file.good()) {
            getline(file, line);
			output.append(line + "\n");
        }
    }
    else {
		std::cerr << "Unable to load shader: " << fileName << std::endl;
    }

    return output;
}

static void CheckShaderError(GLuint shader, GLuint flag, bool isProgram, const std::string& errorMessage) {
    GLint success = 0;
    GLchar error[1024] = { 0 };

    if(isProgram)
        glGetProgramiv(shader, flag, &success);
    else
        glGetShaderiv(shader, flag, &success);

    if(success == GL_FALSE) {
        if(isProgram)
            glGetProgramInfoLog(shader, sizeof(error), NULL, error);
        else
            glGetShaderInfoLog(shader, sizeof(error), NULL, error);

        std::cerr << errorMessage << ": '" << error << "'" << std::endl;
    }
}

GLuint CreateShader(const std::string& text, GLenum shaderType)
{
    GLuint shader = glCreateShader(shaderType);

    if(shader == 0)
		std::cerr << "Error compiling shader type " << shaderType << std::endl;

    const GLchar* p[1];
    p[0] = text.c_str();
    GLint lengths[1];
    lengths[0] = text.length();

    glShaderSource(shader, 1, p, lengths);
    glCompileShader(shader);

    CheckShaderError(shader, GL_COMPILE_STATUS, false, "Error compiling shader!");

    return shader;
}


