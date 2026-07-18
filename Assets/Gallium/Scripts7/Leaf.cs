using UnityEngine;

public class Leaf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()
                 .Grow();

                 LeafManager.Instance.AddLeaf();

            Destroy(gameObject);
        }
    }
}
