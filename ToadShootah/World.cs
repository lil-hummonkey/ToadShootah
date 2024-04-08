namespace ToadShootah;

public class World
{
    Player _player;
    public List<Items> itemsInWorld = new();
    private List<Items> itemsToRemove = new();

    ObjectRenderer staticObjRend = new(Color.Gold), AmmoBoxObjRend = new(Color.DarkBlue), BlackObjRend = new(Color.Black);
    
    WeaponRenderer RotatingObjRend = new(Color.Black);


    List<Actors> actor = new();
    List<Weapons> _weapons = new();
    List <Bullet> _bullets = new();


    public World()
    {
        _player = new Player(new Vector2(400, 82), staticObjRend, this);
        actor.Add(_player);
        _weapons.Add(new Gun(new Vector2(20, 42), RotatingObjRend, this));
        itemsInWorld.Add(new AmmoBox(new Vector2(600, 600), AmmoBoxObjRend));
        itemsInWorld.AddRange(_weapons);

    }
    public void RemoveFromWorld(Items item)
    {
    itemsToRemove.Add(item);
    }

    

    public void Update()
    {
        itemsInWorld.RemoveAll(itemsToRemove.Contains);
        itemsToRemove.Clear();
        actor.ForEach(a => a.Update());
        _weapons.ForEach(w => w.Update());
        _bullets.ForEach(b => b.Update());
    }

    public void Draw()
    {
         actor.ForEach(a => a.Draw());
        itemsInWorld.ForEach(w => w.Draw());
        _player.inventory.ForEach(p => p.Draw());
        _bullets.ForEach(b => b.Draw());
       
    }

    public void AddShotBullet(Vector2 bulletVel, Rectangle gun)
    {
        _bullets.Add(new Bullet(BlackObjRend, new Vector2(gun.X, gun.Y), bulletVel));
        Console.WriteLine($"{itemsInWorld.Count}");
    }
}

//Educations
// futuregames
// tga
// playground squad
// skövde
// uppsala gottland
//Youtube
// GDC
// Game Makers Toolkit
// Brackeys