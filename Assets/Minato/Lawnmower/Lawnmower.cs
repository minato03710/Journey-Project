using System.Collections;
using UnityEngine;

public class Lawnmower : MonoBehaviour
{

    Rigidbody2D rb;
    public bool reachedBoundary; // Checks if boundary reached
    public float horizontalSpeed = 3f;
    private string direction; // Sets movement direction
    private bool movingUp = false;
    private int verticalDirection = -1;
    public float verticalStep = 1f;
    public float verticalSpeed = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Gets the lawnmower's Rigidbody
        direction = "Left";
    }

    // Update is called once per frame
    void Update()
    {
        if(!movingUp)
        {
            transform.Translate(Vector2.right * verticalDirection * horizontalSpeed * Time.deltaTime);
        }

        if(!reachedBoundary) // If the lawnmower has not reached the boundary yet
        {
            Mowing();
        }

        if(reachedBoundary) // If the lawnmower has reached the boundary
        {
            Turning();
        }
    }

    // When a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Left")) // Checks if it is the left boundary
        {
            direction = "Right";
            Turning();
            Debug.Log("Left detected, turning around");
            StartCoroutine(MoveUpThenTurn());
        }

        if(collision.gameObject.CompareTag("Right")) // Checks if it is the right boundary
        {
            direction = "Left";
            Turning();
            Debug.Log("Right detected, turning around");
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
        Debug.Log("Turning");
        // Move up and flip rotation
        // Flip();
        Mowing();
    }

}
