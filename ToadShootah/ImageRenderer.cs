namespace ToadShootah;


//handles rendering of all images within game
public class ImageRenderer: IRenderable
{
protected Color _color;

Texture2D _texture;


//texture is loaded using imgpath as a string parameter for the specific image name
    public ImageRenderer(string imgpath, Color color)
    {
        _color = color;
        
        _texture = Raylib.LoadTexture(imgpath);
    }

//renders the image
    public void Render(Rectangle rect)
    {
        Raylib.DrawTexture(_texture, (int)rect.X, (int)rect.Y,  _color);
    }
}
