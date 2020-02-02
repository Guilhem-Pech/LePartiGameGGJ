using UnityEngine;

namespace States.Environement.Background
{
    public class OnStopStorm : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            AkSoundEngine.PostEvent("Stop_Storm", animator.gameObject);
        }
    }
}