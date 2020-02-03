using States.Environement.Thor;
using UnityEngine;

namespace States.Environement.Background
{
    public class IdleBack : Idle
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            AkSoundEngine.PostEvent("Ambiance_calme", animator.gameObject);
            AkSoundEngine.PostEvent("Stop_Storm", animator.gameObject);
        }
    }
}