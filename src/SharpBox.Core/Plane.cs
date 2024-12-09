using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SharpBox.Core;
using System.Collections.Generic;

public class Plane
{
    private readonly RenderWindow _window;
    private readonly List<Drawable> _drawables; // Stores all drawable objects (points, circles, shapes)
    private readonly List<(Vertex[], PrimitiveType)> _primitives; // Stores raw Vertex arrays with their type

    public int Width { get; }
    public int Height { get; }

    public Plane(int width, int height, string title)
    {
        // Initialize the window
        _window = new RenderWindow(new VideoMode((uint)width, (uint)height), title);
        _window.Closed += (sender, e) => _window.Close();

        // Initialize the drawable objects and vertices lists
        _drawables = [];
        _primitives = [];

        Width = width;
        Height = height;
    }

    public void AddPoint(float x, float y, Color color)
    {
     
        Vertex[] pixel = { new Vertex( new Position(x, y).ToVector2f(Width, Height),color) };

        _primitives.Add((pixel, PrimitiveType.Points));
    }

    public void AddCircle(float x, float y, float radius, Color color)
    {
        // Add a circle to the drawables list
        var circle = new CircleShape(radius)
        {
            FillColor = color,
            Position = new Position(x-radius, y+radius).ToVector2f(Width, Height)
        };
        _drawables.Add(circle);
    }

    public void AddRectangle(float x, float y, float width, float height, Color color)
    {
        // Add a rectangle to the drawables list
        var rectangle = new RectangleShape(new Vector2f(width, height))
        {
            FillColor = color,
            Position = new Position(x, y).ToVector2f(Width, Height)
        };
        _drawables.Add(rectangle);
    }

    public void AddLine(Position fromPosition, Position toPosition, Color color)
    {
        // Add a line using two vertices
        Vertex[] line =
        {
            new Vertex(fromPosition.ToVector2f(Width, Height), color),
            new Vertex(toPosition.ToVector2f(Width, Height), color)
        };
        _primitives.Add((line, PrimitiveType.Lines));
    }

    public void AddGrid(float spacing, float majorLineSpacing, Color minorLineColor, Color majorLineColor)
    {
        // Add vertical lines
        for (float x = -Width / 2f; x <= Width / 2f; x += spacing)
        {
            var color = (MathF.Abs(x) % majorLineSpacing == 0) ? majorLineColor : minorLineColor;
            AddLine(new Position(x, -Height / 2f), new Position(x, Height / 2f), color);
        }

        // Add horizontal lines
        for (float y = -Height / 2f; y <= Height / 2f; y += spacing)
        {
            var color = (MathF.Abs(y) % majorLineSpacing == 0) ? majorLineColor : minorLineColor;
            AddLine(new Position(-Width / 2f, y), new Position(Width / 2f, y), color);
        }
    }

    public void AddText(string content, Position position, uint fontSize, Color color, string fontPath)
    {
        // Load the font
        Font font = new Font(fontPath);

        // Create a Text object
        Text text = new Text(content, font, fontSize)
        {
            FillColor = color,
            Position = position.ToVector2f(Width, Height)
        };

        // Add the Text object to the drawables list
        _drawables.Add(text);
    }


    public void Run()
    {
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear(Color.Black);

            // Draw all drawable objects
            foreach (var drawable in _drawables)
            {
                _window.Draw(drawable);
            }

            // Draw all primitives (points, lines, etc.)
            foreach (var (vertices, primitiveType) in _primitives)
            {
                _window.Draw(vertices, primitiveType);
            }
            _window.Display();
        }
    }
}
