using UnityEngine;

namespace States
{
    public class OnEndGame : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.endScreen.SetActive(true);
        }
    }
}