using UnityEngine;

namespace States
{
    public class OnEndGame : StateMachineBehaviour
    {
        private static readonly int NextState = Animator.StringToHash("NextState");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.endScreen.SetActive(true);
            GameManager.Instance.OnGameOverEnd.AddListener(() => OnGameOver(animator));
        }

        private static void OnGameOver(Animator animator) => animator.SetTrigger(NextState);

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Application.Quit();
        }
    }
}