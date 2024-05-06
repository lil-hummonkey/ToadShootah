namespace ToadShootah;

public abstract class GameObjects
{

    //variable rect used for all gameobjects in child classes
    protected Rectangle _rect;

//checks if a gameobject collides wwith another gameobject
    public bool CollidesWith(GameObjects other)
    {
        return Raylib.CheckCollisionRecs(_rect, other._rect);
    }
    public abstract void Update();
    public abstract void Draw();
}
