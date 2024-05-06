namespace ToadShootah;

//abstract class for all items
public abstract class Items : GameObjects
{
    public virtual void SetPosition(Vector2 position){}
   public bool DrawWhenCarried { get; set; } = false;
   
}
