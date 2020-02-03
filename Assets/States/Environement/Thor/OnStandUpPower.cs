using UnityEngine;

namespace States.Environement.Thor
{
    public class OnStandUpPower : StateMachineBehaviour
    {
        private GameManager _gameManager;
        private static readonly int PrevState = Animator.StringToHash("LowerHammer");
        private Animator _animator;
        private static readonly int Fail = Animator.StringToHash("Fail");
        private static readonly int Success = Animator.StringToHash("Success");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameManager = GameManager.Instance;
            _gameManager.onFailedEvent.AddListener(OnFail);
            _gameManager.onSuccessEvent.AddListener(OnSuccess);
            _animator = animator;
            AkSoundEngine.PostEvent("Play_Music", animator.gameObject);
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameManager.onFailedEvent.RemoveListener(OnFail);
            _gameManager.onSuccessEvent.RemoveListener(OnSuccess);
            AkSoundEngine.PostEvent("Stop_Music", animator.gameObject);

        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_gameManager.HammerPower <= 1f)
            {
                animator.SetTrigger(PrevState);
            }
        }

        private void OnFail()
        {
            _animator.SetTrigger(Fail);
        }

        private void OnSuccess()
        {
            _animator.SetTrigger(Success);
        }

   
    }
}