global using Raylib_cs;
global using System.Numerics;
using ToadShootah;

Raylib.InitWindow(1500, 1000, "Shootah");
Raylib.SetTargetFPS(60);
LevelHandler levels = new LevelHandler();

//runs main code through levels.Run()
while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    levels.Run(); 
    Raylib.ClearBackground(Color.White);
    Raylib.EndDrawing();
}
