using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    private void LoadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadGame()
    {
        //Cuando haya sistema de guardado se podra cargar desde aca
    }

    public void StartNewGame()
    {
        //Cuando haya sistema de guardado esta funcion eliminara los datos que existan.
        LoadLevelByName("LevelSelector");
    }
}
