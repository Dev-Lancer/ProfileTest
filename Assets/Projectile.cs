using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    private IObjectPool<Projectile> pool;
    private float lifeTimer;
    private float maxLifetime;
    private bool isReleased;

    public void Initialize(IObjectPool<Projectile> objectPool, float lifetime)
    {
        pool = objectPool;
        maxLifetime = lifetime;
        lifeTimer = 0f;
        isReleased = false;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifetime && !isReleased)
        {
            isReleased = true;
            pool.Release(this);
        }
    }
}
