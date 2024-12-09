using SFML.Graphics;
using SharpBox.Core;

const int screenWidth = 1200;
const int screenHeight = 600;

// Create the Plane object
var plane = new Plane(screenWidth, screenHeight, "SharpBox Demo");

plane.AddGrid(20, 100, new Color(50, 50, 50,50), new Color(150, 150, 150,100));


//// Add points to the plane

////plane.AddPoint(0, 10, Color.Green);
//plane.AddPoint(0, 0, Color.Yellow);

//for (int i = 0; i < 360; i += 1)
//{
//    float x = 50 * (float)Math.Cos(i * Math.PI / 180);
//    float y = 50 * (float)Math.Sin(i * Math.PI / 180);
//    plane.AddPoint(x, y, Color.White);
//}

//plane.AddRectangle(0, 0, 200, 200, Color.Magenta);
//plane.AddCircle(0, 0, 100, Color.Blue);

//plane.AddLine(new SharpBox.Core.Position(0, 0), new SharpBox.Core.Position(100, 100), Color.Red);   

// Draw sine wave from 0 to 2π
float step = 0.1f; // Determines the smoothness of the wave
float amplitude = 100; // Height of the sine wave
float frequency = 1; // Controls the horizontal stretch

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

// Start the rendering loop
plane.Run();
