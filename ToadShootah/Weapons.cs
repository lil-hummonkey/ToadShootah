namespace ToadShootah;

public abstract class Weapons : Items
{
    protected Vector2 _origin;
    protected float _rotation;
    public abstract void Attack();
   
}
