using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public float moveSpeed = 3f;

    public float areaRadius = 10f;

    public float targetDistance = 0.2f;

    private Vector2 centerPoint;

    private Vector2 targetPosition;

    void Start()
    {
        centerPoint = transform.position;

        PickNewTarget();
    }

    void Update()
    {
        transform.position =
            Vector2.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime);

        if (Vector2.Distance(
            transform.position,
            targetPosition)
            < targetDistance)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        targetPosition =
            centerPoint +
            Random.insideUnitCircle * areaRadius;
    }
}
