#version 330 core

uniform int time;


out vec4 FragColor;

in vec3 coord;

bool inCircle (float radius, float x, float y) {
    return  pow((coord.y - y),2)  + pow((coord.x - x), 2)<= pow(radius,2)  ;
}

bool outCircle (float radius, float x, float y) {
    return  pow(coord.y - y,2)  + pow(coord.x-x, 2)>= pow(radius,2)  ;
}


bool onCircle(float radius, float x, float y) {
    return inCircle(radius, x, y) && outCircle(radius - 0.003f, x, y);
}
bool onCircleWithLength(float radius, float x, float y, float length) {
    return inCircle(radius, x, y) && outCircle(radius -length, x, y);
}


 float X(float radius, float time) {
     return radius*cos(radians(time));
 }
 float Y(float radius, float time) {
     return radius*sin(radians(time));
 }


 float XX(float radius, float a, float time) {
     return a + radius*cos(radians(time));
 }
 float YY(float radius, float b, float time) {
     return b + radius*sin(radians(time));
 }


float speed(float s, float time) {
      return mod((time * s), 360);
  }

void main()
{

    int t = time;

//background
     FragColor = vec4(0.133f, 0.145f, 0.878f, 1.0f);


//Sun
    if(inCircle(0.1f, 0.0f, 0.0f) ) {
             FragColor = vec4(0.878f, 0.854f, 0.133f, 1.0f);
    }

//orbitas
    if(onCircle(0.15f, 0.0f, 0.0f) || onCircle(0.2f, 0.0f, 0.0f) ||  onCircle(0.3f, 0.0f, 0.0f) || onCircle(0.4f, 0.0f, 0.0f) || onCircle(0.55f, 0.0f, 0.0f) || onCircle(0.7f, 0.0f, 0.0f) || onCircle(0.8f, 0.0f, 0.0f) || onCircle(0.9f, 0.0f, 0.0f) ) {
             FragColor = vec4(0.133f, 0.654f, 0.878f, 1.0f);
    }


//Plannets
// Venera, Mars
    if(inCircle(0.02f, X(0.4, speed(0.035f, t)), Y(0.4f, speed(0.035f, t))) || inCircle(0.03f,  X(0.2, speed(0.04f, t)), Y(0.2f, speed(0.04f, t)))) {
        FragColor = vec4(0.878f, 0.431f, 0.133f, 1.0f);
    }
//Mercuri 
    if(inCircle(0.013f,  X(0.15, speed(0.05f, t)), Y(0.15f, speed(0.05f, t))) ) {
        FragColor = vec4(0.686f, 0.858f, 0.337f, 1.0f);
    }

//Earth
    if(inCircle(0.025f, X(0.3, speed(0.05f, t)), Y(0.3f, speed(0.05f, t)))) {
        FragColor = vec4(0.133f, 0.878f, 0.878f, 1.0f);
    }

 //moon
  if (onCircle(0.05f,  X(0.3, speed(0.05f, t)), Y(0.3f, speed(0.05f, t)))) {
             FragColor = vec4(0.133f, 0.654f, 0.878f, 1.0f);
   }
   
   if (inCircle(0.01f, XX(0.05f, X(0.3, speed(0.05f, t)), speed(0.4f, t)), YY(0.05f, Y(0.3, speed(0.05f, t)),  speed(0.4f, t) ) )) {
             FragColor = vec4(0.99f, 0.99f, 0.88f, 1.0f);
   }


   // Yupiter

    if(inCircle(0.06f, X(0.55, speed(0.05f, t)), Y(0.55f, speed(0.05f, t)))) {
        FragColor = vec4(0.78f, 0.858f, 0.337f, 1.0f);
    }


//Saturn
    if(inCircle(0.035f, X(0.7, speed(0.02f, t)), Y(0.7f, speed(0.02f, t)))) {
        FragColor = vec4(0.878f, 0.431f, 0.133f, 1.0f);
    }

    if (onCircleWithLength(0.06f,  X(0.7, speed(0.02f, t)), Y(0.7f, speed(0.02f, t)), 0.015)) {
        FragColor = vec4(0.878f, 0.678f, 0.133f, 1.0f);
    }

    if (onCircle(0.07f, X(0.7, speed(0.02f, t)), Y(0.7f, speed(0.02f, t)))) {
        FragColor = vec4(0.133f, 0.654f, 0.878f, 1.0f);
    }

// Pluton
    if(inCircle(0.02f, X(0.9, speed(0.01f, t)), Y(0.9f, speed(0.01f, t)))) {
        FragColor = vec4(0.133f, 0.878f, 0.878f, 1.0f);
     }


// Neptun

    if(inCircle(0.02f, X(0.8, speed(0.005f, t)), Y(0.8f, speed(0.005f, t)))) {
        FragColor = vec4(0.776f, 0.737f, 0.921f, 1.0f);
    }

 

}