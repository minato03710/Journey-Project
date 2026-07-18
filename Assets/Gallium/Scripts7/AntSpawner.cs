using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;

    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating(
            nameof(SpawnAnt),
            1f,
            spawnInterval);
    }

    void SpawnAnt()
    {
        Instantiate(
            antPrefab,
            transform.position,
            Quaternion.identity);
    }
}
