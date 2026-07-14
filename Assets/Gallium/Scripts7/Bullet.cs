using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(
            direction *
            speed *
            Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
