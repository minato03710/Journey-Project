using UnityEngine;

public class SkinkMain : MonoBehaviour
{

    public SkinkTail tailCheck; // References SkinkTail script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D()
    {
        if(CompareTag("Player")) // Checks if player detected
        {
            if(tailCheck.foundTail) // If player has found tail
            {
                Debug.Log("Change to flower sprite"); // Start ending
            }
        }
    }

}
