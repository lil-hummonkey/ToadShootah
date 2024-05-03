namespace ToadShootah;

public class LevelHandler
{
List<Level> levels = [new Start(), new World()];
Level currentScene;

int sceneNumber = 0;
public void Run()
{
    currentScene = levels[sceneNumber];

    sceneNumber = currentScene.Update();
    currentScene.Draw();

}
}
