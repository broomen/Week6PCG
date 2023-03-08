using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public int damage = 10;
    public float hitDelay = 0.2f; 

    private float hitTimer = 0f;  
    private bool hasHitPlayer = false;  

    private void Update()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (hasHitPlayer)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= hitDelay)
            {
                DealDamage();
                hitTimer = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage();
            hasHitPlayer = true;
            hitTimer = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasHitPlayer = false;
            hitTimer = 0f;
        }
    }

    void DealDamage()
    {
        PlayerHealth playerHealth = target.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
