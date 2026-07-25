using UnityEngine;

public class QueenAntDeath : MonoBehaviour
{
    public AudioSource BossMusicaudioSource;
    public AudioSource regMusic;
    public GameObject Exit;


    private void OnDestroy()
    {
        BossMusicaudioSource.Stop();
        regMusic.Play();
        Exit.SetActive(false);
    }
}
