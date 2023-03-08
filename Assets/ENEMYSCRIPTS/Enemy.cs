using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 40;
    public float damageCooldown = 0.2f;
    public float hitFlashDuration = 0.1f;
    public Color hitFlashColor = Color.red;


    private bool canDealDamage = true;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(HitFlash());
        }
    }

    private IEnumerator HitFlash()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = originalColor;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canDealDamage)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage); // Change the amount of damage as needed
                    StartCoroutine(DamageCooldown());
                }
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDealDamage = true;
    }
}
