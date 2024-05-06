namespace ToadShootah;


//Renders objects with a rotation, i.e weapons
public class WeaponRenderer : IPickupable 
{
    protected Color _color;

  public WeaponRenderer(Color color)
    {
        _color = color;
    }
    public void Render(Rectangle rect, Vector2 origin, float angle = 0)
    {
        Raylib.DrawRectanglePro(rect, origin, angle, _color);
    }
}
