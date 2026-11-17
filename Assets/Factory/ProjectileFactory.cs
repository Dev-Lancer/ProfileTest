using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{
    public enum ProjectileType
    {
        Var1,
        Var2
    }
    [SerializeField] private ProjectileVar1Spawn projectileVar1Spawner;
    [SerializeField] private ProjectileVar2Spawn projectileVar2Spawner;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnsPerSecond = 60f;
    private float spawnTimer;

    public NewProjectile SpawnProjectile(ProjectileType type, Transform spawnPoint, Quaternion rotation)
    {
        if (type == ProjectileType.Var1) 
        {
            return projectileVar1Spawner.SpawnProjectile(spawnPoint);
        }
            
        if(type == ProjectileType.Var2) 
        {
            return projectileVar2Spawner.SpawnProjectile(spawnPoint);
        }
        return null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnsPerSecond <= 0) return;

        float spawnInterval = 1f / spawnsPerSecond;
        spawnTimer += Time.deltaTime;
        while (spawnTimer >= spawnInterval)
        {
            int ran = Random.Range(0, 2);
            if(ran == 0)
            {
                SpawnProjectile(ProjectileType.Var1, spawnPoint, spawnPoint.rotation);
            }
            else if(ran ==1)
            {
                SpawnProjectile(ProjectileType.Var2, spawnPoint, spawnPoint.rotation);
            }

            spawnTimer -= spawnInterval;
        }
    }
}
