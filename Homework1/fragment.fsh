#ifdef GL_ES
precision highp float;
#endif

varying vec4 vColor;

uniform float f; // this is incremented every frame
uniform float t; // this is time in milliseconds since epoch

void main(void) {
  gl_FragColor = vColor * vec4(1.0, 1.0, 1.0, 1.0 - sin(f/100.0)/2.0);
}

