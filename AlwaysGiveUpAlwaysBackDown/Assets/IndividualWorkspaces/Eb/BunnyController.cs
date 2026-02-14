using UnityEngine;
using UnityEngine.InputSystem;

public class BunnyController : MonoBehaviour
{
    public enum BunState { IDLE, RUN, JUMP, FALL }
    private BunState currentState;

    private Rigidbody2D rb;
    public Transform face;
    public Animator faceAnim;
    public GameObject poofParticlePrefab;

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

        currentState = BunState.IDLE;
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

        // update animator
        VisualUpdate();
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

    void VisualUpdate()
    {
        bool isGrounded = IsGrounded();

        // face animations
        if (isGrounded)
        {
            if(Mathf.Abs(moveX) > 0.01f)
            {
                currentState = BunState.RUN;
            }
            else
            {
                currentState = BunState.IDLE;
            }
        }
        else
        {
            if(rb.linearVelocity.y > 0f)
            {
                currentState = BunState.JUMP;
            }
            else
            {
                currentState = BunState.FALL;
            }
        }

        faceAnim.SetInteger("state",  (int) currentState);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contact = col.contacts[0];
        Vector2 hitPoint = contact.point;

        Debug.Log($"Point of contact at: {hitPoint}");
        if (hitPoint != null)
        {
            GameObject poof = Instantiate(poofParticlePrefab);
            poof.transform.position = hitPoint;
        }
    }
}
