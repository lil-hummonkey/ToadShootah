namespace ToadShootah;

 
public class Enemy : Actors
{
    IRenderable _renderer;
    List<Actors> _actors;
    List<Bullet> _bullets;
    Vector2 dir;
    int damage = 1;
    public Enemy(Vector2 pos, IRenderable renderer, List<Actors> actors, List<Bullet> bullets)
    {
        _rect = new(pos.X, pos.Y, 20, 20);
        speed = 4;
        _renderer = renderer;
        _actors = actors;
        _bullets = bullets;
        health = 2;
    }

//Runs OnCollisionEnter for all bullets
    public override void Update()
    {
        Move();
        foreach (Bullet b in _bullets) OnCollisionEnter(b);
    }

//runs OnCollision eneter for all actors
    public void RunCollision()
    {
        foreach (Actors a in _actors) OnCollisionEnter(a);
    }

  //0
 private void OnCollisionEnter(GameObjects other) {
        if (other is Bullet && CollidesWith(other))
        {
          Hurt();
          ((Bullet)other).RunCollision();
        }   
          if (CollidesWith(other) && other is Player)
        { 
         health -= 2;
        }
    }   

  public override void IsAttacking(){}
  public override void Move()
  {
      dir = Vector2.Normalize(dir);
      _rect.X += dir.X*speed;
      _rect.Y += dir.Y*speed;      
  }
  public override void Hurt(){
  health -= damage; 
  Console.WriteLine($"{health}");
  }
  public override void Draw()
    {
        _renderer.Render(_rect);
    }
     public void SetEnemyPosition(Vector2 position)
     {
        dir.X = position.X - _rect.X;
        dir.Y = position.Y - _rect.Y;
     }
}
