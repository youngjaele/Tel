using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float curMovementInput;

    private Rigidbody2D _rigidbody;
    private StatsHandler stats;
    private SpriteRenderer spriteRenderer;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
        stats = GetComponent<StatsHandler>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveSpeed = curMovementInput * stats.CurrentStats.moveSpeed;

        _rigidbody.velocity = new Vector2(moveSpeed, _rigidbody.velocity.y);

        if (curMovementInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (curMovementInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (IsGrounded())
        {
            _rigidbody.gravityScale = 1.0f;
        }
        else
        {
            _rigidbody.gravityScale = 3.0f;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>().x;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = 0.0f;
        }
    }

    public bool IsGrounded()
    {
        float rayLength = 0.5f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        Vector2 rayStartPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);

        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.down, rayLength, groundLayer);

        return hit.collider != null;
    }
}
