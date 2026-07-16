using UnityEngine;

public class AntRadar : MonoBehaviour
{

    Rigidbody2D rb;

    private bool antAlert; // The ant's state - true if it has found the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        antAlert = false; // The ant will begin neutral
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHidden == true) // If the player has entered a shadow, the ant will return to its passive state
        {
            antAlert = false;
        }
    }

    // Called when a game object comes into contact with the ant radar
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) // Checks if the player has been found
        {
            antAlert = true;
            if(antAlert == true)
            {
                // Ant AI script will be called here
            }
        }
    }
}