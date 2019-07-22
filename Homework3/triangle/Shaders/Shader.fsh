//
//  Shader.fsh
//  triangle
//
//  Created by TestUser on 8/4/15.
//  Copyright (c) 2015 TestUser. All rights reserved.
//

varying lowp vec4 colorVarying;

void main()
{
    gl_FragColor = colorVarying;
}
