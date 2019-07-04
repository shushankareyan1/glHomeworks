
attribute vec3 aVertexPosition;
attribute vec4 aVertexColor;

uniform mat4 uMVMatrix;
uniform mat4 uPMatrix;

varying vec4 vColor;

uniform float f; // this is incremented every frame
uniform float t; // this is time in milliseconds since epoch

void main(void) {
    gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, sin(f/100.0) + 2.0);
    vColor = aVertexColor;
}
