namespace ToadShootah;

public class Start : Level
{
    public override int Update()
    {
        if(Raylib.IsKeyPressed(KeyboardKey.Space)) return 1;
        else return 0;
    }
    public override void Draw()
    {
        Raylib.DrawText("Press SPACE to start", 400, 400, 40, Color.Black);
    }
}
