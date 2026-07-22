using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [Header("Settings")]
    public int itemsCollected = 0;
    public int itemsNeeded = 3;

    [Header("Door Reference")]
    public GameObject doorToOpen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we walked into has the "Collectable" tag
        if (other.CompareTag("Collectable"))
        {
            itemsCollected++;
            
            // Destroy the collected item so it vanishes from the scene
            Destroy(other.gameObject);

            // If we collected all 3, disable the door!
            if (itemsCollected >= itemsNeeded)
            {
                if (doorToOpen != null)
                {
                    doorToOpen.SetActive(false); // Disappears the door wall!
                }
            }
        }
    }
}