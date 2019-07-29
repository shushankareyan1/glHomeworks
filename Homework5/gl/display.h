#ifndef DISPLAY_H
#define DISPLAY_H

#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <string>

class Display {
public:
    Display(int, int, const std::string&);
    ~Display();
    GLFWwindow* getWindow();

private:
    GLFWwindow* m_window;
};

#endif
