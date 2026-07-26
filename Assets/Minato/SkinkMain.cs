using UnityEngine;

public class SkinkMain : MonoBehaviour
{

    public SkinkTail tailCheck; // References SkinkTail script
    public Animator animator;
    public BoxCollider2D box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("receivedTail", false);
        box = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Checks if player detected
        {
            Debug.Log("Player not holding tail");
            if(tailCheck.foundTail) // Checks if player has found tail
            {
                Debug.Log("Player holding tail");
                animator.SetBool("receivedTail", true);
                Destroy(box); // Destroys colliders to allow players access to the bridge
            }
        }
    }

}
