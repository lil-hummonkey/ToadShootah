namespace ToadShootah;

public class World
{
    public List<Items> itemsInWorld = new();

    ObjectRenderer playerObjRend = new(Color.Gold);
    ObjectRenderer gunObjRend = new(Color.Black);

    List<Actors> actor = new();
    List<Weapons> _weapons = new();

    public World()
    {
        actor.Add(new Player(new Vector2(400, 82), playerObjRend, this));
        _weapons.Add(new Gun(new Vector2(20, 42), gunObjRend));

        itemsInWorld.AddRange(_weapons);

    }
    public void RemoveFromWorld(Items item)
    {
        itemsInWorld.Remove(item);
    }

    public void Update()
    {
        actor.ForEach(a => a.Update());
    }

    public void Draw()
    {
         actor.ForEach(a => a.Draw());
        _weapons.ForEach(w => w.Draw());
    }
}
