global using Raylib_cs;
global using System.Numerics;
using ToadShootah;

Raylib.InitWindow(800, 600, "Shootah");
Raylib.SetTargetFPS(60);

ObjectRenderer playerObjRend = new(Color.Gold);
ObjectRenderer gunObjRend = new(Color.Black);
World world = new();

List<Actors> actor = new();
List<Weapons> weapon = new();
actor.Add(new Player(new Vector2(400, 82), playerObjRend, world));
weapon.Add(new Gun(new Vector2(20, 42), gunObjRend));

while (!Raylib.WindowShouldClose())
{

    actor.ForEach(a => a.Update());
    // player.OnCollisionEnter(player);


    Raylib.BeginDrawing();
    actor.ForEach(a => a.Draw());
    weapon.ForEach(w => w.Draw());
    Raylib.ClearBackground(Color.White);

    Raylib.EndDrawing();
}
