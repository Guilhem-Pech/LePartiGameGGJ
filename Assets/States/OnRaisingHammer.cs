using UnityEngine;

namespace States
{
    public class OnRaisingHammer : StateMachineBehaviour
    {
        private static readonly int TotalMinigame = Animator.StringToHash("TotalMinigame");
        private static readonly int RandomMinigame = Animator.StringToHash("RandomMinigame");
        private static readonly int NextState = Animator.StringToHash("NextState");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
           int chosen = Random.Range(1, animator.GetInteger(TotalMinigame)); 
           animator.SetInteger(RandomMinigame, chosen);
           animator.SetTrigger(NextState);
        }
    }
}