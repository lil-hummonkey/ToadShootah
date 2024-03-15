namespace ToadShootah;

public abstract class GameObjects
{
    public Vector3 Position { get; set; }
    public Vector3 Size { get; set; }
    protected Rectangle _rect;
    public bool CollidesWith(GameObjects other)
    {
        return Position.X < other.Position.X + other.Size.X &&
               Position.X + Size.X > other.Position.X &&
               Position.Y < other.Position.Y + other.Size.Y &&
               Position.Y + Size.Y > other.Position.Y &&
               Position.Z < other.Position.Z + other.Size.Z &&
               Position.Z + Size.Z > other.Position.Z;;
    }
    public abstract void Update();
    public abstract void Draw();
}
