using Newtonsoft.Json.Bson;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    private bool _isFacingRight = true;
    private bool _isGround = true;
    public bool IsGround
    {
        get => _isGround;
        private set
        {
            _isGround = value;
            controller.anim.SetBool(AnimationString.s_isGrounded, value);
        }
    }

    private void FixedUpdate()
    {
        if (controller.IsAttacking) return;
        if (controller.CanMove)
        {
            Move(controller.MoveValue, controller.CurrentSpeed);
            Jump(controller.IsJumping, controller.jumpingPower);
            IsGround = Physics2D.OverlapCircle(transform.position, 0.2f, controller.groundLayer);
        }
        else
        {
            controller.rb.velocity = Vector2.zero;
        }
    }

    private void Move(float horizontal, float speed)
    {
        SetDirection(horizontal);
        controller.rb.velocity = new Vector2(horizontal * speed, controller.rb.velocity.y);
        controller.anim.SetFloat(AnimationString.s_moveSpeed, controller.CurrentSpeed);
    }

    private void Jump(bool isJumpping, float jumpPower)
    {
        if (controller.anim.GetCurrentAnimatorStateInfo(0).IsName("100-00-Jump-2")) return;
        if (isJumpping && IsGround)
        {
            controller.anim.SetTrigger(AnimationString.s_isJump);
            controller.rb.velocity = new Vector2(controller.rb.velocity.x, jumpPower);
        }
    }
    private void SetDirection(float horizontal)
    {
        if (!_isFacingRight && horizontal > 0f)
        {
            UIManeger.Instance.hpBar.fillOrigin = 0;
            Flip();
        }
        else if (_isFacingRight && horizontal < 0f)
        {
            UIManeger.Instance.hpBar.fillOrigin = 1;
            Flip();
        }
    }
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.parent.localScale;
        localScale.x *= -1f;
        transform.parent.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}