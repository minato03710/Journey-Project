using UnityEngine;
using UnityEngine.SceneManagement;

public class endSceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            openScene();
        }
    }

    public void openScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
