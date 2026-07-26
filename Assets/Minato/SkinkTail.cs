using UnityEngine;

public class SkinkTail : MonoBehaviour
{

    public bool foundTail; // Checks if player has found lost tail

    void Start()
    {
        foundTail = false; // Tail starts not found by player
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) // Checks if player detected
        {
            Debug.Log("Player found tail");
            foundTail = true; // Changes lost tail status to found
            Destroy(gameObject);
        }
    }
}
