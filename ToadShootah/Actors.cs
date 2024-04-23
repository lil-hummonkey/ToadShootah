namespace ToadShootah;

public abstract class Actors : GameObjects
{
  public float speed;
  public float health;
  public abstract void IsAttacking();
  public abstract void Move();
  public abstract void Hurt(); 
  
}
