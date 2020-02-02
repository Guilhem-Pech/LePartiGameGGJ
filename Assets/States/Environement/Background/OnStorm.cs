using UnityEngine;

namespace States.Environement.Background
{
    public class OnStorm : StateMachineBehaviour
    {
        public float minPower = 10f;
        private static int NextState;
        public string nextState = "NextState";

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            NextState = Animator.StringToHash(nextState);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(GameManager.Instance.HammerPower <= minPower)
                animator.SetTrigger(NextState);
        }
    }
}