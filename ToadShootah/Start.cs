namespace ToadShootah;

public class Start : Level
{

    //if space is pressed return 1 so scene changes, otherwise stay on same scene
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
