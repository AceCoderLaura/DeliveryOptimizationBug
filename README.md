# Delivery Optimization Bug
This repository demonstrates a bug in the dosvc caused by the 2004 Windows 10 update that prevents the installation of applications via an appinstaller file.

# Steps
1. Checkout and open the solution in your IDE
2. Right click the PackageApplication.Package project
3. Go to **Publish > Create App Packages...**
4. Click next/create until the build operation starts
5. Run the PackageHost project
6. Open http://localhost:5000/
7. Install the publisher certificate from the **Additional Links** section
8. Click the **Get the app** button
9. Repeat steps 2-8
10. Observe that the package no longer installs
11. Run `Stop-Service -Name "Delivery Optimization"` in an administrator PowerShell window.
12. Repeat steps 2-8
13. Notice that the package installs again
