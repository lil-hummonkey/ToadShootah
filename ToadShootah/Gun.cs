namespace ToadShootah;

public class Gun : Weapons
{
    protected IRenderable _renderer;
    

    public Gun(Vector2 startPos, IRenderable renderer)
    {
        _renderer = renderer;
        _rect = new((int)startPos.X, (int)startPos.Y, 10,40);
        DrawWhenCarried = true;
    }
    public override void Update()
    {
        
    }
    public override void Attack()
    {

    }
    public override void Draw()
    {
        _renderer.Render(_rect);
    }
}
