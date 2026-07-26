using System.Collections;
using UnityEngine;

public class Lawnmower : MonoBehaviour
{

    // Public variables

    public bool reachedBoundary; // Checks if boundary reached
    public float horizontalSpeed = 3f;
    public float verticalStep = 1f;
    public float verticalSpeed = 2f;
    public bool flipAsset = false; // Checks if asset visuals need to be flipped

    // Private variables

    Rigidbody2D rb;
    private bool movingUp = false;
    private string direction; // Sets next movement direction
    private SpriteRenderer visualAsset; // Used for flipping asset visuals


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        visualAsset = GetComponent<SpriteRenderer>();
        direction = "Left"; // Starting movement direction
    }

    // Update is called once per frame
    void Update()
    {
        if(!movingUp) // Waits for vertical movement to be completed before moving horizontally again
        {
            Mowing();
        }

        if(!reachedBoundary) // If the lawnmower has not reached the boundary yet
        {
            Mowing();
        }

        if(reachedBoundary) // If the lawnmower has reached the boundary
        {
            StartCoroutine(MoveUpThenTurn());
        }
    }

    // When a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Left")) // Checks if it is the left boundary
        {
            direction = "Right"; // Move right next
            reachedBoundary = true;
            flipAsset = true;
            Turning();
        }

        else if(collision.gameObject.CompareTag("Right")) // Checks if it is the right boundary
        {
            direction = "Left";
            reachedBoundary = true;
            flipAsset = false;
            Turning();
        }

        else // If it has collided with a game object that isn't a boundary
        {
            Destroy(collision.gameObject); // Destroys the object that it collided with
        }

    }

    IEnumerator MoveUpThenTurn()
    {
        movingUp = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.up * verticalStep;

        while(Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, verticalSpeed * Time.deltaTime);

            yield return null;
        }

        reachedBoundary = false;

    }

    // Default state until lawnmower reaches map boundaries
    void Mowing()
    {

        if(direction == "Left") // Checks if moving left
        {
            rb.AddForce(Vector2.left);
        }

        if(direction == "Right") // Checks if moving right
        {
            rb.AddForce(Vector2.right);
        }

    }

    // Called when lawnmower reaches a map boundary
    void Turning()
    {
        Flip();
        StartCoroutine(MoveUpThenTurn());
    }

    public void Flip()
    {
        if(flipAsset)
        {
            visualAsset.flipX = true; // Flips asset visuals using the sprite renderer
        }

        if(!flipAsset)
        {
            visualAsset.flipX = false;
        }

    }

}
