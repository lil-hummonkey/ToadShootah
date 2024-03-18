namespace ToadShootah;

public abstract class GameObjects
{
    public Vector3 Position { get; set; }
    public Vector3 Size { get; set; }
    protected Rectangle _rect;

    public bool CollidesWith(GameObjects other)
    {
        return Raylib.CheckCollisionRecs(_rect, other._rect);
    }
    public abstract void Update();
    public abstract void Draw();
}
