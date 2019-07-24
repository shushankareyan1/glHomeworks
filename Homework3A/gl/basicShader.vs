#version 330 core

layout (location = 0) in vec3 VertexPosition;

uniform mat4 MVP_matrix;

void main()
{
     vec3 v = vec3(VertexPosition.x - 1.2f, VertexPosition.y + 0.5f, VertexPosition.z);
     gl_Position = vec4(v, 2.0f);
}

