using UnityEngine;
using UnityEngine.Rendering;

public class Shadows : MonoBehaviour
{

    Rigidbody2D rb;
    public bool playerHidden; // Checks if player is hidden

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when any game object comes into contact with this object
    public void OnCollisonEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) // Checks if the game object that it has detected is the player
        {
            Hidden();
        }
    }

    // Called publically across different game objects that the player is now hidden
    public void Hidden()
    {
        playerHidden = true; // The player is now hidden
    }

}
