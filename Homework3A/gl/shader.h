#ifndef Shader_H
#define Shader_H

#include <string>
#include <GL/glew.h>

class Shader {
public:
    Shader(const std::string& fileName, bool step);
    void useProgram(int );


    void Draw();
    ~Shader();

private:
    static const unsigned int NUM_SHADERS = 4;

    GLuint m_program[2];
    GLuint m_shaders[NUM_SHADERS];
   // GLuint m_shaders1[NUM_SHADERS];

};

#endif
