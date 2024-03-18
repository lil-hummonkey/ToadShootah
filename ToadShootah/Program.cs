global using Raylib_cs;
global using System.Numerics;
using ToadShootah;

Raylib.InitWindow(800, 600, "Shootah");
Raylib.SetTargetFPS(60);


World world = new();




while (!Raylib.WindowShouldClose())
{

    world.Update(); 
    


    Raylib.BeginDrawing();
    world.Draw();
   
    Raylib.ClearBackground(Color.White);

    Raylib.EndDrawing();
}
