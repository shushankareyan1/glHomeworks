#version 330 core

out vec4 FragColor;

in vec3 coord;


void main()
{
     FragColor = vec4(0.3f, 0.3f, 0.3f, 1.0f);

    if((coord.x >0 && coord.y <= coord.x && coord.y > 0) ) {
        FragColor = vec4(mod(1/coord.y,2)*0.2, mod(1/coord.y,2)*0.4f,  mod(1/coord.x,2)*0.6f, 1.0f);
    }

}