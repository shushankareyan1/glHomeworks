#include "display.h"
#include <iostream>

Display::Display(int width, int height, const std::string& title) {
    if (!glfwInit()) {
        std::cout << "glfw not initialized\n";
        return;
    }
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    m_window = glfwCreateWindow(width, height, title.c_str(), nullptr, nullptr);
    if (!m_window) {
        std::cout << "Failed to create GLFW window.\n";
        glfwTerminate();
    }
    glfwMakeContextCurrent(m_window);
    glewExperimental = GL_TRUE;
    GLenum status = glewInit();
    if (status != GLEW_OK) {
        std::cout << "Failed to initialized glew\n";
    }
}

Display::~Display() {
    glfwDestroyWindow(m_window);
    glfwTerminate();
}

GLFWwindow* Display::getWindow() {
    return m_window;
}

