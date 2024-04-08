namespace ToadShootah;

public class Bullet : GameObjects
{

IRenderable _renderer;


    public Vector2 pos;
    public Vector2 speed;
    public bool killme = false;
    
    //specific instance in bullet class of position/speed is the position/speed of all bullets.
    //Bullets (circlelol) position is a variable of pos vector 
    public Bullet(IRenderable renderer, Vector2 pos, Vector2 speed)
    {
        this.pos = pos;
        this.speed = speed;
        _renderer = renderer;
        _rect = new Rectangle((int)pos.X - 2, (int)pos.Y - 2, 4, 4);
        
    }

    //updates position according to pos vector

    public override void Update()
    {
        pos += speed;
        _rect.X = pos.X;
        _rect.Y = pos.Y;
       
        
    }



    public override void Draw()
    {
        _renderer.Render(_rect);
    }
}
