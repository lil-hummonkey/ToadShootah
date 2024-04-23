namespace ToadShootah;

public class ImageRenderer: IRenderable
{
protected Color _color;

Texture2D _texture;

    public ImageRenderer(string imgpath, Color color)
    {
        _color = color;
        
        _texture = Raylib.LoadTexture(imgpath);
    }

    public void Render(Rectangle rect)
    {
        Raylib.DrawTexture(_texture, (int)rect.X, (int)rect.Y,  _color);
    }
}
