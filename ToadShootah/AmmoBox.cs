namespace ToadShootah;

public class AmmoBox : Items
{
    protected IRenderable _renderer;
   public AmmoBox(Vector2 pos, IRenderable renderer)
   {
    _renderer = renderer;
    _rect = new((int)pos.X, (int)pos.Y, 18,12);
   } 
   public override void Update(){}

    public override void Draw()
    {
        _renderer.Render(_rect);
    }

}
