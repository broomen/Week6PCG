using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
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

        if (input != Vector2.zero)
        {
            animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);
            lastInput = input;
        }

        animator.SetFloat("Speed", input.magnitude);

        transform.position += new Vector3(input.x, input.y) * speed * Time.deltaTime;
    }
}
