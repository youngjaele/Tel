using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerSO", order = 1)]
public class PlayerSO : ScriptableObject
{
    [Header("Player Data")]
    public int hp;
    public int atk;
    public float moveSpeed;
    public float atkDelay;
    public LayerMask target;

    [Header("Player Knockback Data")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}

