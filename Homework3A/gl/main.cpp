#include <GL/glew.h>
#include <iostream>

#include "display.h"
#include "shader.h"
#include <cmath>

int main(int argc, const char* argv[]) {
    // Create window
    Display display(800, 800, "Screen");
    // Create shader from file
    Shader shader("./basicShader", false);

    // Add shader program into GPU
    // Loop for window
    while(!glfwWindowShouldClose(display.getWindow()))
    {
      
        glClearColor(0.3f, 0.3f, 0.3f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        // Write your draw logic here
        shader.useProgram(1);
        shader.Draw();
        shader.useProgram(0);
        shader.Draw();


        glfwSwapBuffers(display.getWindow());
        glfwPollEvents();

        if (glfwGetKey(display.getWindow(), GLFW_KEY_ESCAPE) == GLFW_PRESS)
            glfwSetWindowShouldClose(display.getWindow(), GL_TRUE);
    }
}
