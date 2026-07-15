using UnityEngine;

public class AntAI : MonoBehaviour
{
    public float speed = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction =
            (player.position - transform.position).normalized;

        transform.position +=
            (Vector3)direction * speed * Time.deltaTime;
    }
}
