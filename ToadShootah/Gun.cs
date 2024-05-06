namespace ToadShootah;

public class Gun : Weapons
{
    protected IPickupable _renderer;
    float angle;
    World _world;
    Vector2 bulletVel = new Vector2();
    float shootCooldownMax = 0.5f;
    float shootCooldownValue;
    public int shotsLeft { get; set; }



//defines important fields as the parameter which fits them
    public Gun(Vector2 startPos, IPickupable renderer, World world)
    {
        _renderer = renderer;
        _world = world;
        _rect = new((int)startPos.X, (int)startPos.Y, 40, 10);
        _origin = new(0, 0);
        _rotation = angle;
        shootCooldownValue = shootCooldownMax;
        shotsLeft = 10;
    }
    public override void Update()
    {
    shootCooldownValue -= Raylib.GetFrameTime();
    Raylib.DrawText($"Bullets:{shotsLeft}", 1400, 10, 20, Color.Black);

    }
  
    public override void Draw()
    {
        _renderer.Render(_rect, _origin, angle);
    }

//gun position is picked based on position (which is given in Player.cs as player rect) and the guns position is changed to match said player position
//angle is decided here using the Arctangent of the adjacent and opposite sides of the triangle between the mouse and player
//runs ShootBullets() and uses it to decide shootCooldownValue
    public override void SetPosition(Vector2 position)
    {
        _rect.X = position.X + 18;
        _rect.Y = position.Y + 18;
        angle = MathF.Atan2
        (position.Y - Raylib.GetMouseY()
        , position.X - Raylib.GetMouseX()) * Raylib.RAD2DEG;
        angle += 180;
        shootCooldownValue = ShootBullets(shootCooldownValue, bulletVel, angle, _world);
    }

//If the shoot cooldown has ended, you press left mouse click and you have bullets left bulletVel will pick a direction for bullet to travel in
//AddShotBullet() is in world as each bullet is an object being added to the world in the game
//resets cooldown and subtracts one bullet from ammo

    float ShootBullets(float shootCooldownValue, Vector2 bulletVel, float rotation, World world)
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && shootCooldownValue < 0)
        {
            if (shotsLeft > 0)
            {
                bulletVel.Y = (float)Math.Sin(rotation * Raylib.DEG2RAD) * 10;
                bulletVel.X = (float)Math.Cos(rotation * Raylib.DEG2RAD) * 10;
                world.AddShotBullet(bulletVel, _rect);
                shotsLeft -= 1;
                shootCooldownValue = 0.5f;
                
            }
        }
        return shootCooldownValue;
    }
}
