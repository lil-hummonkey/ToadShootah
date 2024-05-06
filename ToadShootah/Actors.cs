namespace ToadShootah;

public abstract class Actors : GameObjects
{
  public float speed { get; set; }
  public float health { get; set; }
  public abstract void IsAttacking();
  public abstract void Move();
  public abstract void Hurt(); 
  
}
