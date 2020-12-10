using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    public int DamageOnCollision = 20;

    private Transform target;
    private int destPoint;

    void Start()
    {
        target = waypoints[0];
    }
    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f) //si ennemi est quasiment à sa destination
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(DamageOnCollision);
        }
    }
}

