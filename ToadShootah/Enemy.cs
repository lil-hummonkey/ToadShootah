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
        Speed = 4;
        _renderer = renderer;
        _actors = actors;
        _bullets = bullets;
        Health = 2;
    }

//Runs OnCollisionEnter for all bullets
    public override void Update()
    {
        Move();
        foreach (Bullet b in _bullets) OnCollisionEnter(b);
    }

//runs OnCollision enter for all actors
    public void RunCollision()
    {
        foreach (Actors a in _actors) OnCollisionEnter(a);
    }

  //If a collision happens between bullet and an enemy Hurt() will run, as well as RunCollision() within bullet (which removes bullet right after)
  //RunCollision() runs if a player is hit by an enemy, wherein the second if is run and the enemy dies instantaniously upon collision with player
 private void OnCollisionEnter(GameObjects other) {
        if (other is Bullet && CollidesWith(other))
        {
          Hurt();
          ((Bullet)other).RunCollision();
        }   
          if (CollidesWith(other) && other is Player)
        { 
         Health -= 2;
        }
    }   

  public override void IsAttacking(){}

  //moves player using speed as movement speed variable and dir as location vector
  public override void Move()
  {
      dir = Vector2.Normalize(dir);
      _rect.X += dir.X*Speed;
      _rect.Y += dir.Y*Speed;      
  }

    //runs health code, where each time its run enemy loses 1 health
  public override void Hurt(){
  Health -= damage; 
  Console.WriteLine($"{Health}");
  }

  //draws out rect (enemy)
  public override void Draw()
    {
        _renderer.Render(_rect);
    }

//makes dir vector be a differens between player position and enemy position (enemy moves toward player)
     public void SetEnemyPosition(Vector2 position)
     {
        dir.X = position.X - _rect.X;
        dir.Y = position.Y - _rect.Y;
     }
}
