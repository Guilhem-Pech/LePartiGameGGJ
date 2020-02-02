using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States.Minigames
{
    public class OnMinigameControlledSmash : UnityEngine.StateMachineBehaviour
    {
        private GameManager _gameManager;
        private static readonly int PrevState = Animator.StringToHash("PrevState");
        private InputAction _useAction;
        private float _timerEnd;
        private static readonly int Success = Animator.StringToHash("Success");
        private static readonly int Fail = Animator.StringToHash("Fail");

        public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _gameManager = GameManager.Instance;
            _gameManager.currentState.SetText("Minigame");
            _gameManager.GetPlayerInput().actions.FindAction("Use").performed += OnUse;
            _timerEnd = _gameManager.GetTimerMinigameEnd();
            
        }


        private void OnUse(InputAction.CallbackContext callbackContext)
        {
            _gameManager.HammerPower += _gameManager.gameManagerData.smashAddForce;

        }

        public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _gameManager.GetPlayerInput().actions.FindAction("Use").performed -= OnUse;
            _gameManager.percentage.SetFixInt((int) _gameManager.HammerPower);
        }

        public override void OnStateUpdate(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _gameManager.HammerPower -= _gameManager.gameManagerData.decreasePowerPerSecond * Time.deltaTime;
            if (_gameManager.HammerPower < _gameManager.gameManagerData.thresholdReturnToIdle) 
                animator.SetTrigger(PrevState);
            _timerEnd -= Time.deltaTime;
            
            if (_timerEnd < 0)
            {
                animator.SetTrigger(_gameManager.HammerPower < _gameManager.gameManagerData.kaboomThreshold ? Success : Fail);
            }
        }
    }
}