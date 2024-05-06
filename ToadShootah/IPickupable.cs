
namespace ToadShootah;

//Contains render method for WeaponRenderer
public interface IPickupable
{   

//gives a rect, and origin and an angle (rotation)
void Render(Rectangle rect, Vector2 origin, float angle);
   
}
