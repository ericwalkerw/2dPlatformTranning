using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour, ICollectBuff
{
    public float walkSpeed = 2f;
    public float runSpeed = 8f;
    public float jumpingPower = 5f;

    public Animator anim;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public HealthSystem healthCS;
    public float CurrentSpeed
    {
        get
        {
            if (CanMove)
            {

                if (IsMoving && !IsAttacking)
                {
                    if (IsRunning) return runSpeed;
                    else return walkSpeed;
                }
                return 0;
            }
            return 0;
        }
    }
    public bool IsMoving => MoveValue != 0;
    public float MoveValue => InputSystem.Instance.MoveInput;
    public bool IsJumping => InputSystem.Instance.JumpInput;
    public bool IsRunning => InputSystem.Instance.RunInput;
    public bool IsAttacking => InputSystem.Instance.AttackInput;
    public bool CanMove { get => this.anim.GetBool(AnimationString.s_canMove); }

    public void AttackBuff()
    {
        healthCS.damage += 5;
    }

    public void HPBuff()
    {
        healthCS.currentHP = healthCS.maxHp;
    }

    public void JumpBuff()
    {
        jumpingPower += 6;
    }
}
