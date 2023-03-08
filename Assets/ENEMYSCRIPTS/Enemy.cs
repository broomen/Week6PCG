using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{ 
    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 2f;
    public int damage = 10;
    public float hitDelay = 0.2f;

    private float hitTimer = 0f;  
    private bool hasHitPlayer = false;  

    private PlayerMovement target;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    { 
        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            target = player;
            hasHitPlayer = true;
            hitTimer = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            target = null;
            hasHitPlayer = false;
            hitTimer = 0f;
        }
    }

    public void TakeDamage(int damage, Vector2 pushForce, float stunDuration, Vector2 knockbackDirection)
    {
        currentHealth -= damage;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 force = knockbackDirection.normalized * pushForce;
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        StartCoroutine(Stun(stunDuration));
        
        if (currentHealth <= 0)
        {
            Die();
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

    IEnumerator Stun(float stunDuration)
    {
        speed = 0f;

        yield return new WaitForSeconds(stunDuration);

        speed = 2f;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
