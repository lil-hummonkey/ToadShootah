global using Raylib_cs;
global using System.Numerics;
using ToadShootah;

Raylib.InitWindow(1500, 1000, "Shootah");
Raylib.SetTargetFPS(60);

World world = new World();

while (!Raylib.WindowShouldClose())
{

    world.Update(); 
    


    Raylib.BeginDrawing();
    world.Draw();
   
    Raylib.ClearBackground(Color.White);

    Raylib.EndDrawing();
}
