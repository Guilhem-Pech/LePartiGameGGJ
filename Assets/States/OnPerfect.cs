using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;

namespace States
{
    public class OnPerfect : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.currentState.SetText("YOU NAILED IT");

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