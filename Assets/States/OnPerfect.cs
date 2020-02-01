using UnityEngine;

namespace States
{
    public class OnPerfect : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("YOU NAILED IT");
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.HammerPower = 0f;
        }

    }
}