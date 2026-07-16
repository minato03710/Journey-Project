using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead = false;

    // 受伤后无敌时间
    public float invincibleTime = 1f;

    private bool invincible = false;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 只检测蚂蚁
        if (!other.CompareTag("Enemy"))
            return;

        // 无敌状态下不受伤
        if (invincible)
            return;

        // 尝试移除一节身体
        bool lostBody = playerController.RemoveBodyPart();

        // 还有身体
        if (lostBody)
        {
            Debug.Log("Lost 1 body part");

            StartCoroutine(Invincible());

            return;
        }

        // 没有身体了
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
