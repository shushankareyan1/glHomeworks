#ifdef GL_ES
precision highp float;
#endif

varying vec4 vColor;

uniform float f; // this is incremented every frame
uniform float t; // this is time in milliseconds since epoch

void main(void) {
  gl_FragColor = vColor; 
}

