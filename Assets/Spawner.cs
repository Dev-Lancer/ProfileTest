using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnsPerSecond = 60f;
    [SerializeField] private float objectLifetime = 1f;

    private float spawnTimer;

    private void Update()
    {
        if (spawnsPerSecond <= 0) return;

        float spawnInterval = 1f / spawnsPerSecond;
        spawnTimer += Time.deltaTime;
        while (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer -= spawnInterval;
        }
    }
    public void SpawnObject()
    {
        if (objectPrefab == null) return;
        Transform targetTransform = spawnPoint != null ? spawnPoint : transform;
        Vector3 randomOffset = Random.insideUnitSphere * 0.5f;
        GameObject obj = Instantiate(objectPrefab, targetTransform.position + randomOffset, targetTransform.rotation);
        Destroy(obj, objectLifetime);
    }
}
