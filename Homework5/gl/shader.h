#ifndef Shader_H
#define Shader_H

#include <string>
#include <GL/glew.h>

class Shader {
public:
    Shader(const std::string& fileName, bool step);
    void useProgram(int );
    void changeTime(int time);


    void Draw();
    ~Shader();

private:
    static const unsigned int NUM_SHADERS = 2;

    GLuint m_program[1];
    GLuint m_shaders[NUM_SHADERS];

};

#endif
