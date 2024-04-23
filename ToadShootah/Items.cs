namespace ToadShootah;

public abstract class Items : GameObjects
{
    public virtual void SetPosition(Vector2 position){}
   public bool DrawWhenCarried = false;
   
}
