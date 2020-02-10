using UnityEngine;

namespace States
{
    public class OnSuccessUI : StateMachineBehaviour
    {
        public AK.Wwise.Event myEvent;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            AkSoundEngine.PostEvent(myEvent.Id,animator.gameObject);
            
        }
    }
}