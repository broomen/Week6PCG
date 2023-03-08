using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float rollSpeedMultiplier = 10f; 
    private Animator animator;
    private Vector2 input;
    private Vector2 lastInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }   

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        float currentSpeed = speed;
        if (Input.GetKeyDown(KeyCode.LeftShift)) // check if left shift key is pressed
        {
            if (input.y > 0) // up roll animation
            {
                animator.SetTrigger("RollUp");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.y < 0) // down roll animation
            {
                animator.SetTrigger("RollDown");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.x > 0) // right roll animation
            {
                animator.SetTrigger("RollRight");
                currentSpeed *= rollSpeedMultiplier;
            }
            else if (input.x < 0) // left roll animation
            {
                animator.SetTrigger("RollLeft");
                currentSpeed *= rollSpeedMultiplier;
            }
        }
        else // normal movement animation
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
    }
    

}
