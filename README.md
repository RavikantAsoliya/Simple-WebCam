# Simple_WebCam

**Windows Forms application for capturing and displaying webcam video using the AForge.NET library.**

Simple_WebCam is a user-friendly Windows Forms application designed for capturing webcam video and providing a real-time display. With an intuitive interface, users can effortlessly choose their desired webcam device, initiate video capture, and enjoy a live feed. Alongside essential functionalities like fullscreen mode and flip capability, the application also enables users to save the state, ensuring a seamless experience between sessions. As an open-source project released under the MIT License, Simple_WebCam welcomes community contributions, making it ideal for developers seeking to enhance its features. Whether you're a developer or a user in search of a customizable webcam solution, Simple_WebCam offers versatility and ease of use.

[![License](https://img.shields.io/github/license/RavikantAsoliya/simple-webcam)](https://opensource.org/licenses/MIT)
[![Issues](https://img.shields.io/github/issues/RavikantAsoliya/simple-webcam)](https://github.com/your-username/simple-webcam/issues)
[![Stars](https://img.shields.io/github/stars/RavikantAsoliya/simple-webcam)](https://github.com/your-username/simple-webcam/stargazers)
[![Forks](https://img.shields.io/github/forks/RavikantAsoliya/simple-webcam)](https://github.com/your-username/simple-webcam/network/members)

## Features

- Select and start a webcam device from the available list.
- Stop the camera and release the device.
- Pin the application window to be always on top.
- Toggle between full-screen and normal modes.
- Flip the camera image horizontally.
- Customize the window shape with rounded corners (round mode).
- Save and restore the application's state and location.
- Drag the application window by clicking and dragging the title bar.
- Double-click the video display area to toggle between normal and full-screen modes.

## Prerequisites

- Windows operating system
- .NET Framework

## Installation

1. Clone or download the Simple_WebCam repository to your local machine.
2. Open the project in Visual Studio.
3. Build the project to compile the code and resolve dependencies.
4. Run the application, and the Simple_WebCam window will appear.

## Usage

1. Upon launching the application, you will see the Simple_WebCam window.
2. Right-click on the window to open the context menu.
3. Select a webcam device from the "Devices" submenu to start capturing video from that device.
4. The video feed will be displayed in the main area of the window.
5. To stop the camera, right-click again and choose the "Stop" option from the context menu.
6. Use the other options in the context menu to customize the application's behavior (e.g., pinning the window, toggling full-screen mode, and flipping the camera image).
7. To exit the application, select the "Exit" option from the context menu or click the close button (X) in the window's title bar.

## Configuration

- By default, the application will save the previous state and location. This means that if you move or resize the window, it will start at the same position the next time you launch the application.
- The application's configuration is stored in the config file, which you can modify if needed.

## Contributing

Contributions to Simple_WebCam are welcome! If you find any issues or have suggestions for improvements, please submit a pull request or open an issue in the GitHub repository.

## License

Simple_WebCam is licensed under the [MIT License](https://opensource.org/licenses/MIT). You are free to use, modify, and distribute the software.

## Credits

Simple_WebCam was developed using the AForge.NET library, which provides video capture and processing capabilities.

## Acknowledgments

Special thanks to the developers of AForge.NET for their valuable contribution to the project.

---

Feel free to customize the README file based on your specific project requirements and add any additional sections or information that may be relevant.
