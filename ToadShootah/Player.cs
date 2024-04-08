
using System.Numerics;

namespace ToadShootah;

public class Player : Actors
{
    World _world;
    

    private Vector2 _velocity;
    protected float _speed = 1;
    protected IRenderable _renderer;

    public List<Items> bullets = new();
    public List<Items> inventory = new();

    public Player(Vector2 startPos, IRenderable renderer, World world)
    {
        _rect = new((int)startPos.X, (int)startPos.Y, 40, 40);
        _velocity = new Vector2();
        _renderer = renderer;
        _world = world;
    }

    public override void Update()
    {
        Move();

        _world.itemsInWorld.ForEach(OnCollisionEnter);

        inventory.ForEach(i => i.SetPosition(new(_rect.X, _rect.Y)));
        
    }
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


        _rect.X += _velocity.X * _speed;
        _rect.Y += _velocity.Y * _speed;

    }

    public void Pickup(Items item)
    {
        if (item is Weapons)
        {
        inventory.Add(item);
        _world.RemoveFromWorld(item);

        }
        if (item is AmmoBox){
        _world.RemoveFromWorld(item);
            Console.WriteLine("yuh");
foreach (Items i in inventory) if (i is Gun) ((Gun)i).shotsLeft += 10;
           
           
        }
    }

    public void OnCollisionEnter(GameObjects other)
    {
        if (other is Items && CollidesWith(other))
        {
            Pickup((Items)other);

        }
    }
    public override void IsAttacking() { }
    public override void Hurt() { }
  
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
