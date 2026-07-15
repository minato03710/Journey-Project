using UnityEngine;
using TMPro;

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

        Time.timeScale = 0;
    }
}
