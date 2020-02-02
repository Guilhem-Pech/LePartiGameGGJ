using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;

namespace States
{
    public class OnPerfect : StateMachineBehaviour
    {
        private static readonly int PrevState = Animator.StringToHash("PrevState");
        private static readonly int NextState = Animator.StringToHash("NextState");
        private static readonly int Stop = Animator.StringToHash("Stop");
        private static readonly int PreventRestart = Animator.StringToHash("PreventRestart");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("YOU NAILED IT");
            GameManager.Instance.onSuccessEvent.Invoke();

            GameManager.Instance.NailProgress += (int) GameManager.Instance.HammerPower < 20f
                ? (int) (GameManager.Instance.HammerPower * 0.5)
                : (int) GameManager.Instance.HammerPower;

            Timer.Register(5f,() => animator.SetTrigger(GameManager.Instance.NailProgress < 100 ? PrevState : NextState));
            CanvasGroup canvasGroup = GameManager.Instance.canvasUI.GetComponent<CanvasGroup>();
            DOTween.To(() => canvasGroup.alpha, value => canvasGroup.alpha = value, 0f, 1);
            GameManager.Instance.backgroundAnimator.SetTrigger(Stop);
            GameManager.Instance.backgroundAnimator.SetBool(PreventRestart,true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.HammerPower = 0f;
            GameManager.Instance.backgroundAnimator.SetBool(PreventRestart,false);

        }

    }
}