using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button loadButton;
    private void Start()
    {
        if (SaveControl.DataExists())
        {
            loadButton.interactable = true;
        }
        else
        {
            loadButton.interactable = false;
        }
    }
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
        GameManager.Instance.LoadData();
        LoadLevelByName("LevelSelector");
    }

    public void StartNewGame()
    {
        SaveControl.DeletePlayerData();
        GameManager.Instance.SetPlayerDefaultStats();
        LoadLevelByName("LevelSelector");
    }
}
