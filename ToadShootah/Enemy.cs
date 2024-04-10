namespace ToadShootah;

 
public class Enemy : Actors
{
    IRenderable _renderer;
    Player _player;
    List<Bullet> _bullets;
    Vector2 dir;
    int damage = 1;

    public Enemy(Vector2 pos, IRenderable renderer, Player player, List<Bullet> bullets)
    {
        _rect = new(pos.X, pos.Y, 20, 20);
        speed = 4;
        _renderer = renderer;
        _player = player;
        _bullets = bullets;
        health = 2;
    }

    public override void Update()
    {
        Move();
        foreach (Bullet b in _bullets) OnCollisionEnter(b);

    }

    private void OnCollisionEnter(GameObjects other) {
        if (other is Bullet && CollidesWith(other))
        {
          Hurt();
          ((Bullet)other).RunCollision();
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
