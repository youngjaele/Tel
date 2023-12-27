using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private StatsHandler stats;
    private AnimationController animationController;

    private int jumpCount = 1;
    private bool canjump = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        stats = GetComponent<StatsHandler>();
        animationController = GetComponent<AnimationController>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && ( IsGrounded() || jumpCount > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, stats.CurrentStats.jumpForce);
            animationController.Jumping();

            if (!IsGrounded()) 
            {
                jumpCount--;
                canjump = false;
            }

            Debug.Log($"³²Àº È½¼ö : {jumpCount}");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 rayStartPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);

        Gizmos.DrawRay(rayStartPosition + (Vector2)(transform.right * 0.5f), Vector2.down);
        Gizmos.DrawRay(rayStartPosition + (Vector2)(-transform.right * 0.5f), Vector2.down);
    }

    public bool IsGrounded()
    {
        float rayLength = 0.5f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        Vector2 rayStartPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);

        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.down, rayLength, groundLayer);

        if (hit.collider != null && !canjump)
        {
            jumpCount = 1;
            canjump = true;
            Debug.Log($"È½¼ö ÃÊ±âÈ­ {jumpCount}");
        }

        return hit.collider != null;
    }
}
