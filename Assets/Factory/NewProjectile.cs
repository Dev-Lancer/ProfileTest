using UnityEngine;

public abstract class NewProjectile : MonoBehaviour
{
    private float lifeTimer;
    private float maxLifetime = 1f;
    [SerializeField] private float speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifetime)
        {
            Destroy(this);
        }
    }
}
