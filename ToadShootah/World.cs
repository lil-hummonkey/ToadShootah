namespace ToadShootah;

public class World
{
    Player _player;
    Gun gun;
    public List<Items> itemsInWorld = new();

    public World()
    {
        itemsInWorld.Add(gun);
    }
    public void RemoveFromWorld(Items item)
   {
    itemsInWorld.Remove(item);
   }
}
