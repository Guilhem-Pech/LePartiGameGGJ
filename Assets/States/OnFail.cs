using UnityEngine;

namespace States
{
    public class OnFail : StateMachineBehaviour
    {
        private static readonly int NextState = Animator.StringToHash("NextState");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("KABOOOOM");
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.HammerPower = 0f;
        }
        
    }
}