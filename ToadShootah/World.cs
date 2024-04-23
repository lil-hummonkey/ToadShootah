namespace ToadShootah;
public class World
{
    Player _player;
    public List<Items> itemsInWorld = new();
    public List<Actors> actor = new();
    private List<Items> itemsToRemove = new();
    ObjectRenderer AmmoBoxObjRend = new(Color.DarkBlue), BlackObjRend = new(Color.Black), EnemyObjRend = new(Color.Red);
    WeaponRenderer RotatingObjRend = new(Color.Black);
    ImageRenderer PlayerImage = new(@"ToaderAnim.png", Color.White);
    List<Weapons> _weapons = new();
    List <Bullet> _bullets = new();
    Random enemyPosGenerator = new Random();
    Random enemyTimer = new Random();
    Vector2 enemyPos;
    float enemySpawnTime;
//Instantiate the classes and set enemy spawn timer
    public World()
    {
        _player = new Player(new Vector2(400, 82), PlayerImage, this);
        actor.Add(_player);
        _weapons.Add(new Gun(new Vector2(20, 42), RotatingObjRend, this));
        itemsInWorld.Add(new AmmoBox(new Vector2(600, 600), AmmoBoxObjRend));
        itemsInWorld.AddRange(_weapons);
        enemySpawnTime = enemyTimer.Next(5,10);
    }
    //adds items to list itemsToRemove to later remove said items
    public void RemoveFromWorld(Items item)
    {
    itemsToRemove.Add(item);
    }
//removes all items in itemsInWorld that are also in itemsToRemove, as well as removes all items within itemsToRemove
//run updates for all superclasses, as well as running generall methods
//remove all objects which fill a certain criteria
    public void Update()
    {
        itemsInWorld.RemoveAll(itemsToRemove.Contains);
        itemsToRemove.Clear();
        actor.ForEach(a => a.Update());
        _weapons.ForEach(w => w.Update());
        _bullets.ForEach(b => b.Update());
        SpawnEnemy();
        actor.RemoveAll(a => a.health == 0);
        _bullets.RemoveAll(b => b.killme);
    }
//if the spawntimer is below zero run AddEnemy()
    void SpawnEnemy(){
        enemySpawnTime -= Raylib.GetFrameTime();
        if (enemySpawnTime < 0) AddEnemy();
    }
//randomises a location, spawns an enemy and resets the timer
    public void AddEnemy(){
        enemyPos.X = enemyPosGenerator.Next(100, 900);
        enemyPos.Y = enemyPosGenerator.Next(100, 900);
        actor.Add(new Enemy(enemyPos, EnemyObjRend, actor, _bullets));
        enemySpawnTime = enemyTimer.Next(5,10);
    }
//run draw for all superclasses
    public void Draw()
    {
         actor.ForEach(a => a.Draw());
        itemsInWorld.ForEach(w => w.Draw());
        _player.inventory.ForEach(p => p.Draw());
        _bullets.ForEach(b => b.Draw());
    
    }
//adds a bullet to the world once method is run
    public void AddShotBullet(Vector2 bulletVel, Rectangle gun)
    {
        _bullets.Add(new Bullet(BlackObjRend, new Vector2(gun.X, gun.Y), bulletVel, actor));
        
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