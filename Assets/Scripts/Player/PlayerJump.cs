using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private StatsHandler stats;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        stats = GetComponent<StatsHandler>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && PlayerController.instance.IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, stats.CurrentStats.jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 rayStartPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);

        Gizmos.DrawRay(rayStartPosition + (Vector2)(transform.right * 0.5f), Vector2.down);
        Gizmos.DrawRay(rayStartPosition + (Vector2)(-transform.right * 0.5f), Vector2.down);
    }
}
