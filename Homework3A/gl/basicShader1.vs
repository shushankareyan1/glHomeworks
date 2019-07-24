#version 330 core

layout (location = 0) in vec3 VertexPosition;

uniform mat4 MVP_matrix;

out vec3 coord;


void main()
{

    gl_Position = vec4(VertexPosition, 1.0f); 
    coord = VertexPosition;
}