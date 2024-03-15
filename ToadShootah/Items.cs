namespace ToadShootah;

public abstract class Items : GameObjects
{
   public bool DrawWhenCarried = false;
   
   public void AttachToPlayer(Player player)
   {
      this.Position = player.Position; 
   }
   public virtual void SetPosition(Vector2 position)
   {
        _rect.X = position.X;
        _rect.Y = position.Y;
   }
}
