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
            GameManager.Instance.onFailedEvent.Invoke();
            CanvasGroup canvasGroup = GameManager.Instance.canvasUI.GetComponent<CanvasGroup>();
            DOTween.To(() => canvasGroup.alpha, value => canvasGroup.alpha = value, 0f, 1);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.NailProgress = 0;
            GameManager.Instance.HammerPower = 0f;
        }
        
    }
}