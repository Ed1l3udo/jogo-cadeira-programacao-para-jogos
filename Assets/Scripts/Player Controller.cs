using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Animator animator;
    private bool isMoving = false;
    private bool isRunning = false;
    Vector2 moveInput;

    public bool isMoving { 
        get
        {
            return isMoving;
        }
        private set
        {
            isMoving = value;
        }
        animator.SetBool("isMoving", value);
    }

    public bool isRunning {
        get
        {
            return isRunning;
        }
        private set
        {
            isRunning = value;
        }
        animator.SetBool("isRunning", value);
    }

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * walkSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        isMoving = (moveInput != Vector2.zero);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValue<bool>;
    }
}
