#version 330 core

out vec4 FragColor;

in vec3 coord;

bool inCircle (float radius, float x, float y) {
    return  pow((coord.y - y),2) <= pow(radius,2) - pow((coord.x - x), 2) ;
}

bool outCircle (float radius, float x, float y) {
    return  pow(coord.y - y,2) >= pow(radius,2) - pow(coord.x-x, 2) ;
}


bool onCircle(float radius, float x, float y) {
    return inCircle(radius, x, y) && outCircle(radius -0.003f, x, y);
}
bool onCircleWithLength(float radius, float x, float y, float length) {
    return inCircle(radius, x, y) && outCircle(radius -length, x, y);
}

void main()
{
//background
     FragColor = vec4(0.133f, 0.145f, 0.878f, 1.0f);


//Sun
    if(inCircle(0.1f, 0.0f, 0.0f) ) {
             FragColor = vec4(0.878f, 0.854f, 0.133f, 1.0f);
    }

//orbitas
    if(onCircle(0.15f, 0.0f, 0.0f) || onCircle(0.2f, 0.0f, 0.0f) ||  onCircle(0.3f, 0.0f, 0.0f) || onCircle(0.4f, 0.0f, 0.0f) || onCircle(0.6f, 0.0f, 0.0f) || onCircle(0.8f, 0.0f, 0.0f) || onCircle(0.9f, 0.0f, 0.0f) ) {
             FragColor = vec4(0.133f, 0.654f, 0.878f, 1.0f);
    }


//Plannets
//Mercuri , Venera, Mars
    if(inCircle(0.01f, 0.15f, 0.0f) || inCircle(0.04f, 0.0f, -0.4f) || inCircle(0.02f, 0.0f, -0.2f)) {
        FragColor = vec4(0.878f, 0.431f, 0.133f, 1.0f);
    }

//Earth
    if(inCircle(0.02f, 0.0f, 0.3f)) {
        FragColor = vec4(0.133f, 0.878f, 0.878f, 1.0f);
    }

//Uran
    if(inCircle(0.05f, -0.6f, 0.0f)) {
        FragColor = vec4(0.878f, 0.431f, 0.133f, 1.0f);
    }

    if (onCircleWithLength(0.08f, -0.6f, 0.0f, 0.02)) {
        FragColor = vec4(0.878f, 0.678f, 0.133f, 1.0f);
    }

    if (onCircle(0.09f, -0.6f, 0.0f)) {
        FragColor = vec4(0.133f, 0.654f, 0.878f, 1.0f);
    }

// Pluton

    if(inCircle(0.02f, 0.4f, -sqrt(pow(0.9f,2) - pow(0.4f,2)))) {
        FragColor = vec4(0.133f, 0.878f, 0.878f, 1.0f);
    }

// Neptun

    if(inCircle(0.015f, -0.4f, sqrt(pow(0.8f,2) - pow(0.f,2)))) {
        FragColor = vec4(0.776f, 0.737f, 0.921f, 1.0f);
    }

 

}