using SFML.System;

namespace SharpBox.Core;
public class Position
{
    public Position(float x, float y)
    {
        X = x;
        Y = y;
    }

    public float X { get; set; }
    public float Y { get; set; }

    public Vector2f ToVector2f(int screenWidth, int screenHeight)
    {
        float px = X + screenWidth / 2;
        float py = screenHeight / 2 - Y;
        return new Vector2f(px, py);
    }
}
