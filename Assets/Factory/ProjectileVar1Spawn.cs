using UnityEngine;

public class ProjectileVar1Spawn : SpawnerBase
{
    public GameObject projectileVar1Prefab;
    public override NewProjectile SpawnProjectile(Transform spawnPoint)
    {
        GameObject projectile = Instantiate(projectileVar1Prefab, spawnPoint);
        return projectile.GetComponent<NewProjectile>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
