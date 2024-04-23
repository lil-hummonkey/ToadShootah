namespace ToadShootah;

public abstract class GameObjects
{
    protected Rectangle _rect;

    public bool CollidesWith(GameObjects other)
    {
        return Raylib.CheckCollisionRecs(_rect, other._rect);
    }
    public abstract void Update();
    public abstract void Draw();
}
