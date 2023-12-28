using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;

    protected StatsHandler stats;
    protected Transform ClosestTarget { get; private set; }

    private void Awake()
    {
        stats = GetComponent<StatsHandler>();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        ClosestTarget = gameManager.Player;
    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}
