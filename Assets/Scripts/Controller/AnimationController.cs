using System.Collections;
using UnityEngine;

public class AnimationController : _Animation
{
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(controller.curMovementInput, 0.0f);
        Running(moveInput);
    }

    public void Running(Vector2 obj)
    {
        animator.SetBool(Run, obj.magnitude > 0.5f);   
    }

    public void Jumping()
    {
        animator.SetBool(Jump, true);
        StartCoroutine(ResetJumpAnimation());
    }

    IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(Jump, false);
    }
}
