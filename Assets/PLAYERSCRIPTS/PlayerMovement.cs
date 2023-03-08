using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float rollSpeedMultiplier = 10f; 
    [SerializeField] private float meleeRange = 1.5f;
    [SerializeField] private int meleeDamage = 40;
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private GameObject hitEffectPrefab; // New variable for the hit effect prefab

    private Animator animator;
    private Vector2 input;
    private Vector2 lastInput;
    private PlayerHealth playerHealth;
    private float lastDashTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }   

    private void Update()
    {
        if (playerHealth.currentHealth <= 0) 
        {
            input = Vector2.zero;
            animator.SetFloat("Speed", 0f);
            return;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        float currentSpeed = speed;
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown) 
        {
            lastDashTime = Time.time;

            if (input.y > 0) 
            {
                animator.SetTrigger("RollUp");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.y < 0) 
            {
                animator.SetTrigger("RollDown");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.x > 0) 
            {
                animator.SetTrigger("RollRight");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.x < 0) 
            {
                animator.SetTrigger("RollLeft");
                currentSpeed *= rollSpeedMultiplier;
            }
        }
        else 
        {
            if (input != Vector2.zero)
            {
                animator.SetFloat("Horizontal", input.x);
                animator.SetFloat("Vertical", input.y);
                lastInput = input;
            }
            animator.SetFloat("Speed", input.magnitude);
        }

        transform.position += new Vector3(input.x, input.y) * currentSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 meleeTarget = transform.position + new Vector3(lastInput.x, lastInput.y) * meleeRange;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(meleeTarget, 0.5f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Enemy enemy = collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(meleeDamage);
                        // Spawn hit effect at the enemy's position
                        Instantiate(hitEffectPrefab, enemy.transform.position, Quaternion.identity);
                    }
                }
            }

            if (lastInput.x > 0)
            {
                animator.SetTrigger("AttackRight");
            }
            else if (lastInput.x < 0)
            {
                animator.SetTrigger("AttackLeft");
            }
            else if (lastInput.y > 0)
            {
                animator.SetTrigger("AttackUp");
            }
            else if (lastInput.y < 0)
            {
                animator.SetTrigger("AttackDown");
            }
        }
    }
}
