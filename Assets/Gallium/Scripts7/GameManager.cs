using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverText.SetActive(false);
    }

public void GameOver()
    {
        gameOverText.SetActive(true);

        // Schedules LoadMainMenu to run after 2 seconds
        Invoke(nameof(LoadMainMenu), 2.0f);
    }

    private void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}
