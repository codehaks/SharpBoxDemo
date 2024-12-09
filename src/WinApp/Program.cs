using SFML.Graphics;

const int screenWidth = 800;
const int screenHeight = 600;

// Create the Plane object
var plane = new Plane(screenWidth, screenHeight, "SharpBox Demo");

// Add points to the plane

//plane.AddPoint(0, 10, Color.Green);
plane.AddPoint(0, 0, Color.Yellow);

for (int i = 0; i < 360; i += 1)
{
    float x = 50 * (float)Math.Cos(i * Math.PI / 180);
    float y = 50 * (float)Math.Sin(i * Math.PI / 180);
    plane.AddPoint(x, y, Color.White);
}

plane.AddRectangle(0, 0, 200, 200, Color.Magenta);
plane.AddCircle(0, 0, 100, Color.Blue);

plane.AddLine(new SharpBox.Core.Position(0, 0), new SharpBox.Core.Position(100, 100), Color.Red);   

// Start the rendering loop
plane.Run();
