namespace ToadShootah;

public class Gun : Weapons
{
    protected IPickupable _renderer;
    float angle;
    World _world;
    Vector2 bulletVel = new Vector2();
    float shootCooldownMax = 0.5f;
    float shootCooldownValue;
    public int shotsLeft;

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
    public override void Attack()
    {

    }
    public override void Draw()
    {
        _renderer.Render(_rect, _origin, angle);
    }

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



    float ShootBullets(float shootCooldownValue, Vector2 bulletVel, float rotation, World world)
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && shootCooldownValue < 0)
        {
            if (shotsLeft > 0)
            {
                bulletVel.Y = (float)Math.Sin(rotation * Raylib.DEG2RAD) * 10;
                bulletVel.X = (float)Math.Cos(rotation * Raylib.DEG2RAD) * 10;
                world.AddShotBullet(bulletVel, _rect);
                CheckBulletsLeft();
                shootCooldownValue = 0.5f;
                
            }
        }
        return shootCooldownValue;
    }
    void CheckBulletsLeft()
    {
        if (shotsLeft > 0) shotsLeft -= 1;
    }
}
