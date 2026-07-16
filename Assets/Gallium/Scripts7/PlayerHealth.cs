using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead = false;

    // no hurt time
    public float invincibleTime = 1f;

    private bool invincible = false;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // only ant
        if (!other.CompareTag("Enemy"))
            return;

        // no hurt time
        if (invincible)
            return;

        // remove body
        bool lostBody = playerController.RemoveBodyPart();

        // have body
        if (lostBody)
        {
            Debug.Log("Lost 1 body part");

            StartCoroutine(Invincible());

            return;
        }

        // no body
        Die();
    }

    IEnumerator Invincible()
    {
        invincible = true;

        yield return new WaitForSeconds(invincibleTime);

        invincible = false;
    }

    void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("Player Died");

        GameManager.Instance.GameOver();
    }
}
