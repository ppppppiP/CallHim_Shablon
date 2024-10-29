using UnityEngine;
using Zenject;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float minY = -1f;
    public float maxY = 2f;
    [Inject] DiContainer container;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, spawnRate);
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        container.InstantiatePrefab(pipePrefab, new Vector3(transform.localPosition.x, randomY, transform.parent.position.z),  Quaternion.identity, transform.parent);
    }
}
