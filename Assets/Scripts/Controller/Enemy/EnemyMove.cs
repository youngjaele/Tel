using UnityEngine;

public class EnemyMove : EnemyController
{
    private Rigidbody2D _rigidbody;
    private int nextMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Invoke("Think", 3f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Think()
    {
        nextMove = Random.Range(-1, 2);
        CancelInvoke();
        Invoke("Think", 3f);
    }

    private void Move()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        _rigidbody.velocity = new Vector2(nextMove, _rigidbody.velocity.y);
        Vector2 front = new Vector2(transform.position.x + nextMove * 0.5f, transform.position.y);

        RaycastHit2D hit = Physics2D.Raycast(front, Vector2.down, 1, groundLayer);

        if (hit.collider == null)
        {
            Debug.Log("Àýº®");
            nextMove = nextMove * (-1);
            Invoke("Think", 2f);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 front = new Vector2(transform.position.x + nextMove * 0.5f, transform.position.y - 0.3f);

        Gizmos.DrawRay(front, Vector3.down);
    }
}
