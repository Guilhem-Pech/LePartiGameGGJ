using DG.Tweening;
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
            DOTween.To(() => GameManager.Instance.HammerPower, value => GameManager.Instance.HammerPower = value, 0,
                5 * 0.9f);
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.NailProgress = 0;
            GameManager.Instance.HammerPower = 0f;
        }
        
    }
}