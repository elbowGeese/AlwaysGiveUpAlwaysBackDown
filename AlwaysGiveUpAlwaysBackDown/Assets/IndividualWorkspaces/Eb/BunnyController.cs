using UnityEngine;
using UnityEngine.InputSystem;

public class BunnyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform face;

    private InputAction moveInput;
    private InputAction jumpAction;

    private float moveX = 0f;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public float groundedRayDistance = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveInput = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        // move input
        moveX = moveInput.ReadValue<Vector2>().x;
        if(moveX > 0f)
        {
            face.localScale = new Vector2(1f, 1f);
        }
        else if(moveX < 0f)
        {
            face.localScale = new Vector2(-1f, 1f);
        }

        // jump input
        if (jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            // jump output
            rb.AddForce(jumpForce * new Vector2(0f, 1f), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // move output
        rb.linearVelocity = new Vector2(moveX * moveSpeed * Time.fixedDeltaTime, rb.linearVelocity.y);
    }

    bool IsGrounded()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -Vector2.up, groundedRayDistance);
        Debug.DrawRay(transform.position, groundedRayDistance * -Vector2.up, Color.red, 1f);

        Debug.Log(hits.Length);
        if (hits.Length > 0)
        {
            foreach(RaycastHit2D hit in hits)
            {
                if(!hit.collider.gameObject.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
