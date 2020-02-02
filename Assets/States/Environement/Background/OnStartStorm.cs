using UnityEngine;

namespace States.Environement.Background
{
    public class OnStartStorm : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            AkSoundEngine.PostEvent("Stop_Ambiance_calme", animator.gameObject);
            AkSoundEngine.PostEvent("Play_Storm", animator.gameObject);
            AkSoundEngine.PostEvent("Woosh_Nuage", animator.gameObject);
        }
    }
}