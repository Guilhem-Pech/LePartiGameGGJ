using UnityEngine;

namespace States.Environement.Background
{
    public class OnStopStorm : StateMachineBehaviour
    {
        private static readonly int NextState = Animator.StringToHash("NextState");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            AkSoundEngine.PostEvent("Stop_Storm", animator.gameObject);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger(NextState);
        }
    }
}