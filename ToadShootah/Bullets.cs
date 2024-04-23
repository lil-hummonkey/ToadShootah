namespace ToadShootah;

public class Bullet : Items
{

IRenderable _renderer;

    public bool killme = false;
     Vector2 pos;
     Vector2 speed;
     List<Actors> _actors;
     
    
    //specific instance in bullet class of position/speed is the position/speed of all bullets.
    //Bullets position is a variable of pos vector 
    public Bullet(IRenderable renderer, Vector2 pos, Vector2 speed, List<Actors> actors)
    {
        this.pos = pos;
        this.speed = speed;
        _renderer = renderer;
        _rect = new Rectangle((int)pos.X - 2, (int)pos.Y - 2, 4, 4);
        _actors = actors;
    }

    //updates position according to pos vector

    public override void Update()
    {
        pos += speed;
        _rect.X = pos.X;
        _rect.Y = pos.Y;
    
        
    }

     public void RunCollision()
     {
        foreach (GameObjects a in _actors) OnCollisionEnter(a);
     }
    void OnCollisionEnter(GameObjects other) {
        
        
        if (CollidesWith(other) && other is Enemy)
        { 
          killme = true;
        }
    }


    public override void Draw()
    {
        _renderer.Render(_rect);
    }
}
