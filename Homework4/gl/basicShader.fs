#version 330 core

out vec4 FragColor;

in vec3 coord;


void main()
{
     FragColor = vec4(1.0f, 0.3f, 0.3f, 1.0f);

    if( pow(coord.y,2) <= pow(0.3,2) - pow(coord.x, 2) ) {
        discard;
    }

}
