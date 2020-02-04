using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class OnFail : StateMachineBehaviour
    {
        private static readonly int NextState = Animator.StringToHash("NextState");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("KABOOOOM");
            GameManager.Instance.onFailedEvent.Invoke();
            GameManager.Instance.ShowUI(false);
            GameManager.Instance.ShowUIButton(false);

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.NailProgress = 0;
            GameManager.Instance.HammerPower = 0f;
        }
        
    }
}