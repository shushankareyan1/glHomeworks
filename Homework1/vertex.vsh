
attribute vec3 aVertexPosition;
attribute vec4 aVertexColor;

uniform mat4 uMVMatrix;
uniform mat4 uPMatrix;

varying vec4 vColor;
varying vec3 vPosition;

uniform float f; // this is incremented every frame
uniform float t; // this is time in milliseconds since epoch

void main(void) {


    gl_Position = uPMatrix * uMVMatrix * vec4(aVertexPosition, 2.0);

   vColor = vec4(1.0, 0.0, 0.0, 1.0);
   float time = mod(t /1.0, 14.0);
if(time == aVertexPosition.r) {
   vColor =  vec4(0.0, .0, 1.0, 1.0);
} 

}
