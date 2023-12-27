using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttack", menuName = "SO/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Data")]
    public int atk;
    public float delay;
    public float speed;
    public float size;
    public LayerMask target;

    [Header("Knock Back Data")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
