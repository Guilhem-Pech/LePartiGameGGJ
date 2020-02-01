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

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("YOU NAILED IT");

            GameManager.Instance.NailProgress += (int) GameManager.Instance.HammerPower < 20f
                ? (int) (GameManager.Instance.HammerPower * 0.5)
                : (int) GameManager.Instance.HammerPower;

            Timer.Register(5f,() => animator.SetTrigger(GameManager.Instance.NailProgress < 1f ? PrevState : NextState));
            
            DOTween.To(() => GameManager.Instance.HammerPower, value => GameManager.Instance.HammerPower = value, 0,
                5 * 0.7f);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.HammerPower = 0f;
        }

    }
}