using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem>
{
    public float MoveInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool RunInput { get; private set; }
    public bool AttackInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context) => MoveInput = context.ReadValue<Vector2>().x;

    public void OnJump(InputAction.CallbackContext context) => JumpInput = context.performed;

    public void OnRun(InputAction.CallbackContext context) => RunInput = context.performed;
    public void OnAttack(InputAction.CallbackContext context) => AttackInput = context.performed;
}
