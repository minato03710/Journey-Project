using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // eat ants
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            return;
        }

        // eat player
        if (other.CompareTag("Player"))
        {
            // hiding
            if (Shadows.playerHidden)
                return;

            PlayerHealth player =
                other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.SendMessage("Die");
            }
        }
    }
}
