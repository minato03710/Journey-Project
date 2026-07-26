using UnityEngine;

public class River : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController player = other.GetComponent<PlayerController>();

        if (player == null)
            return;

        if (!player.onTurtle)
        {
            player.waterTimer += Time.deltaTime;

            if (player.waterTimer >= 1f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            player.waterTimer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.waterTimer = 0f;
        }
    }
}