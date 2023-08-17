using UnityEngine;

public class SetBoolBehavior : StateMachineBehaviour
{
    public string boolName;
    public bool updateOnState;
    public bool UpdateOnStateMachine;
    public bool valueOnEnter, valueOnExit;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }
    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (UpdateOnStateMachine)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (UpdateOnStateMachine)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }
}
