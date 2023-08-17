using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController controller;
    private void Update()
    {
        if (controller.CanMove && controller.IsAttacking)
        {
            Attack();
        }
    }
    private void Attack()
    {
        if (controller.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        controller.anim.SetTrigger(AnimationString.s_isAttack);
    }
}
