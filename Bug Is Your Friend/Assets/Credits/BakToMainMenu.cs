using UnityEngine;

public class BakToMainMenu : MonoBehaviour
{
    public LevelLoader LevelLoader;

    public  void BackToMainMenu()
    {
        LevelLoader.LoadLevelByIndex(1);
    }

}
