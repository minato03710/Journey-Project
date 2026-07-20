using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // This variable holds the text "UI"
    [SerializeField] private string gameplaySceneName = "GameScene"; 

    public void OnPlayButtonClicked()
    {
        // Pass the variable name here so Unity reads whatever is typed in the Inspector
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Game Closed!");
    }
}