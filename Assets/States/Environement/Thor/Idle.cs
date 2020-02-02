using UnityEngine;

namespace States.Environement.Thor
{
    public class Idle : StateMachineBehaviour
    {
        private GameManager _gameManager;
        private static readonly int NextState = Animator.StringToHash("NextState");
        public float minPower = 1f;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameManager = GameManager.Instance;
            _gameManager.canvasUI.GetComponent<CanvasGroup>().alpha = 0f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if(_gameManager.HammerPower >= minPower)
                animator.SetTrigger(NextState);
        }
    }
}