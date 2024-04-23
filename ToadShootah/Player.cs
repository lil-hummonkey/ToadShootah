
using System.Numerics;

namespace ToadShootah;

public class Player : Actors
{
    World _world;
    private Vector2 _velocity;
    protected IRenderable _renderer;
    public List<Items> inventory = new();
    public Player(Vector2 startPos, IRenderable renderer, World world)
    {
        _rect = new((int)startPos.X, (int)startPos.Y, 40, 40);
        _velocity = new Vector2();
        _renderer = renderer;
        _world = world;
        speed = 1;
        health = 3;
    }

    //Runs OnCollisionEnter for every item in list itemsInWorld (i.e. every item in currently lying around in world)
    //sets position of every object within inventory to players position
    //runs OnCollisionEnter for every actor in world, as well as checks whether the actor is an Enemy, if it is then set Enemy position to player (so it chases player)
    public override void Update()
    {
        Move();
        _world.itemsInWorld.ForEach(OnCollisionEnter);
        inventory.ForEach(i => i.SetPosition(new(_rect.X, _rect.Y)));
        foreach (Actors a in _world.actor)
        {
        OnCollisionEnter(a);
        if (a is Enemy) ((Enemy)a).SetEnemyPosition(new(_rect.X, _rect.Y)); 
        }
        Raylib.DrawText($"Health:{health}", 1400, 35, 20, Color.Black);
    }

    //changes velocity based on if player presses WASD, making WASD movement controller
    //makes rect position be affected by velocity
    public override void Move()
    {
        _velocity = Vector2.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            _velocity.X = -5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            _velocity.X = 5;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            _velocity.Y = 5;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            _velocity.Y = -5;
        }
        _rect.X += _velocity.X * speed;
        _rect.Y += _velocity.Y * speed;
    }

    //if Item picked up is Weapon, add to inventory list and add to RemoveFromWorld list (which removes item from world)
    //if Item is AmmoBox, remove from world and add +10 bullets to ammo by searching for Gun in inventory
    public void Pickup(Items item)
    {
        if (item is Weapons)
        {
        inventory.Add(item);
        _world.RemoveFromWorld(item);
        }
        if (item is AmmoBox){
        _world.RemoveFromWorld(item);
        foreach (Items i in inventory) if (i is Gun) ((Gun)i).shotsLeft += 10;
        }
    }

    //takes a gameObject in the form of other; if other is Item run PickUp(),
    //if other is Enemy run Hurt() and run RunCollision() within enemy so that the enemy despawns after doing damage
    void OnCollisionEnter(GameObjects other)
    {
        if (other is Items && CollidesWith(other))
        {
            Pickup((Items)other);
        }
          if (other is Enemy && CollidesWith(other))
        {
          Hurt();
          ((Enemy)other).RunCollision();
        }   
    }
    public override void IsAttacking() { }
    public override void Hurt() 
    {
        health -= 1;
        Console.WriteLine($"{health}");
    }
    public override void Draw()
    {
        _renderer.Render(_rect);
        List<Items> items = inventory.Where(i => i.DrawWhenCarried == true).ToList();
        foreach (Items i in items)
        {
            i.Draw();
        }
    }
}