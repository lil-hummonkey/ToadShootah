﻿

namespace ToadShootah;

//Handles rendering of all objects without special property
public class ObjectRenderer : IRenderable
{
    protected Color _color;

    public ObjectRenderer(Color color)
    {
        _color = color;
    }
    public void Render(Rectangle rect)
    {
        Raylib.DrawRectangleRec(rect, _color);
    }

}
