//
//  Shader.vsh
//  triangle
//
//  Created by TestUser on 8/4/15.
//  Copyright (c) 2015 TestUser. All rights reserved.
//

attribute vec4 position;
attribute vec3 normal;

varying lowp vec4 colorVarying;

uniform mat4 modelViewProjectionMatrix;
uniform mat3 normalMatrix;

void main()
{
    vec3 eyeNormal = normalize(normalMatrix * normal);
    vec3 lightPosition = vec3(0.0, 0.0, 2.0);
    vec4 diffuseColor = vec4(0.3, 0.2, 0.1, 1.0);
    
    float nDotVP = max(0.0, dot(eyeNormal, normalize(lightPosition)));
                 
    colorVarying = diffuseColor * nDotVP;
    
    gl_Position = modelViewProjectionMatrix * position;
}
