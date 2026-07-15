using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player Died");

        GameManager.Instance.GameOver();

        Destroy(gameObject);
    }
}
