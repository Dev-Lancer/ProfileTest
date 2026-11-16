using UnityEngine;
using UnityEngine.Pool;

public class NewSpawner : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnsPerSecond = 60f;
    [SerializeField] private float objectLifetime = 1f;
    [SerializeField] private int defaultCapacity = 70;
    [SerializeField] private int maxPoolSize = 100;
    private IObjectPool<Projectile> projectilePool;
    private float spawnTimer;

    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(
            createFunc: CreateProjectile,
            actionOnGet: OnTakeFromPool,
            actionOnRelease: OnReturnedToPool,
            actionOnDestroy: OnDestroyPoolObject,
            collectionCheck: false,
            defaultCapacity: defaultCapacity,
            maxSize: maxPoolSize
        );
    }
    private Projectile CreateProjectile()
    {
        return Instantiate(projectilePrefab);
    }

    private void OnTakeFromPool(Projectile instance)
    {
        Transform target = spawnPoint != null ? spawnPoint : transform;
        Vector3 randomOffset = Random.insideUnitSphere * 0.5f;

        instance.transform.SetPositionAndRotation(target.position + randomOffset, target.rotation);
        instance.gameObject.SetActive(true);
        instance.Initialize(projectilePool, objectLifetime);
    }

    private void OnReturnedToPool(Projectile instance)
    {
        instance.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Projectile instance)
    {
        Destroy(instance.gameObject);
    }

    private void Update()
    {
        if (spawnsPerSecond <= 0f) return;

        float spawnInterval = 1f / spawnsPerSecond;
        spawnTimer += Time.deltaTime;

        while (spawnTimer >= spawnInterval)
        {
            projectilePool.Get();
            spawnTimer -= spawnInterval;
        }
    }
}
