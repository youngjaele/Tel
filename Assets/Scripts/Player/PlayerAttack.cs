using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private CharacterController characterController;
    private AnimationController animationController;
    private StatsHandler stats;

    public Transform attackPos;
    public Vector2 attackSize;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animationController = GetComponent<AnimationController>();
        stats = GetComponent<StatsHandler>();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Collider2D[] collider = Physics2D.OverlapBoxAll(attackPos.position, attackSize, 0);
            
            foreach (Collider2D col in collider) 
            {
                if (col.tag == "Enemy")
                {
                    // 공격 함수
                    Debug.Log("공격");
                }
            }

            animationController.Attacking();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(attackPos.position, attackSize);
    }
}
