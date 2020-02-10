using UnityEngine;

namespace States
{
    public class OnSuccessUI : StateMachineBehaviour
    {
        public AK.Wwise.Event myEvent;
        public AK.Wwise.Event uiEvent;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            myEvent.Post(animator.gameObject);
            uiEvent.Post(animator.gameObject);
        }
    }
}