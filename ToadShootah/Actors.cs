namespace ToadShootah;

public abstract class Actors : GameObjects
{
  public float Speed { get; set; }
  public float Health { get; set; }
  public abstract void IsAttacking();
  public abstract void Move();
  public abstract void Hurt(); 
  
}
