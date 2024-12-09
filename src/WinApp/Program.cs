using SFML.Graphics;
using SharpBox.Core;

const int screenWidth = 1200;
const int screenHeight = 600;

// Create the Plane object
var plane = new Plane(screenWidth, screenHeight, "SharpBox Demo");

plane.AddGrid(20, 100, new Color(50, 50, 50,50), new Color(150, 150, 150,100));

for (int i = 0; i < 360; i += 10)
{
    float x = 50 * (float)Math.Cos(i * Math.PI / 180);
    float y = 50 * (float)Math.Sin(i * Math.PI / 180);
    plane.AddPoint(x, y, Color.Green);
}

plane.AddRectangle(100, 0, 200, 200, Color.Magenta);
plane.AddCircle(-200, 200, 20, Color.Yellow);

// Draw sine wave from 0 to 2π
float step = 0.1f; // Determines the smoothness of the wave
float amplitude = 100; // Height of the sine wave

for (float x = -MathF.PI; x < MathF.PI; x += step)
{
    // Calculate the start and end points of each line segment
    float y1 = MathF.Sin(x) * amplitude;
    float y2 = MathF.Sin(x + step) * amplitude;

    // Adjust horizontal scaling (frequency) and vertical spacing
    float startX = x * 100; // Scale x-axis
    float endX = (x + step) * 100;

    // Add line segments to draw the sine wave
    plane.AddLine(
        new Position(startX, y1),
        new Position(endX, y2),
        Color.Cyan
    );
}

// Add some text
string fontPath = "C:\\Windows\\Fonts\\CascadiaMono.ttf"; // Replace with a valid path to a .ttf font file

plane.AddText("Sin(x)", new Position(-200, 0), 18, Color.Cyan, fontPath);


// Start the rendering loop
plane.Run();
