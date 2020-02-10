using UnityEngine;


namespace States
{
    public class OnFail : StateMachineBehaviour
    {
        private static readonly int NextState = Animator.StringToHash("NextState");
        private Animator _animator;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _animator = animator;
            GameManager.Instance.currentState.SetText("KABOOOOM");
            GameManager.Instance.onFailedEvent.Invoke();
            GameManager.Instance.ShowUI(false);
            GameManager.Instance.ShowUIButton(false);
            GameManager.Instance.OnGameOverEnd.AddListener(OnGameOverEnd);
            GameManager.Instance.HammerPower = 0f;

        }

        private void OnGameOverEnd()
        {
            _animator.SetTrigger(NextState);
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            GameManager.Instance.NailProgress = 0;
            GameManager.Instance.OnGameOverEnd.RemoveListener(OnGameOverEnd);
        }
        
    }
}