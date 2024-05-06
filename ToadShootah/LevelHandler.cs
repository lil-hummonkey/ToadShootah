namespace ToadShootah;

//takes care of which level should be played at any given moment using Update as an int which returns scene number
//Levels is a list of all levels with their respective information within them.
public class LevelHandler
{
List<Level> levels = [new Start(), new World()];
Level currentScene;

int sceneNumber = 0;

//makes currentscene a Level variable which runs Update and Draw for respective level
//current level is picked by choosing a specific object in List<Level>, scenenumber says which object to be picked
public void Run()
{
    currentScene = levels[sceneNumber];

    sceneNumber = currentScene.Update();
    currentScene.Draw();

}
}
