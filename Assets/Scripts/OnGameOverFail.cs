using UnityEngine;

public class OnGameOverFail : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        GameManager.Instance.OnGameOverEnd.Invoke();
    }
}