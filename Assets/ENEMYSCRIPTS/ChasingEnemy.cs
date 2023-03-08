using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public int damage = 10;
    public float hitDelay = 0.2f;
    public GameObject agro;

    private float hitTimer = 0f;  
    private bool isHitting = false;  

    private void Update()
    {
        target = agro.GetComponent<Agro>().target;
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (isHitting)
        {
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0f)
            {
                hitTimer = hitDelay;
                DealDamage();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isHitting = true;
            hitTimer = hitDelay;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isHitting = false;
            hitTimer = 0f;
        }
    }

    void DealDamage()
    {
        if (isHitting)
        {
            PlayerHealth playerHealth = target.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
