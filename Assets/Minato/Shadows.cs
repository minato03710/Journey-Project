using UnityEngine;
using UnityEngine.Rendering;

public class Shadows : MonoBehaviour
{
    
    public static bool playerHidden; // Checks if player is hidden

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when a game object comes into contact with this object
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the game object that it has detected is the player
        if(collision.gameObject.CompareTag("Player"))
        {
            // Calls the function to set the player's state to hidden
            Hidden();
        }
    }

    // Called when a game object leaves the shadow
    public void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the game object that it has detected is the player
        if(collision.gameObject.CompareTag("Player"))
        {
            // Calls the function to set the player's state to visible
            Exited();
        }
    }

    // Called publically that the player is now hidden
    public void Hidden()
    {
        Debug.Log("Player hidden");
        playerHidden = true; // The player is now hidden
    }

    // Called publically that the player is now visible
    public void Exited()
    {
        Debug.Log("Player visible");
        playerHidden = false; // The player is no longer hidden
    }

}