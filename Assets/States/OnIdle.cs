using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class OnIdle : StateMachineBehaviour
    {
        private GameManager _gameManager;
        private Animator _animator;
        private static readonly int NextState = Animator.StringToHash("NextState");
        private InputAction _useAction;
        private CanvasGroup canvasGroup;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _animator = animator;
            _gameManager = GameManager.Instance;
            _useAction =  _gameManager.GetPlayerInput().actions.FindAction("Use");
            _useAction.performed += OnUse;
            _gameManager.currentState.SetText("Idle");
            canvasGroup = _gameManager.canvasUIHammer;
        }

        private void OnUse(InputAction.CallbackContext arg0)
        {
            _gameManager.HammerPower += _gameManager.gameManagerData.idleAddForce;
            if(_gameManager.HammerPower > _gameManager.gameManagerData.minHammerPowerEnteringMinigame)
                _animator.SetTrigger(NextState);

            _gameManager.WitchDeviceWasUse(arg0.control.device);

        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_gameManager.HammerPower > 0)
            {
                _gameManager.HammerPower -= _gameManager.gameManagerData.decreasePowerPerSecond * Time.deltaTime;
                if (_gameManager.HammerPower > 2f && canvasGroup.alpha <= 0f)
                {
                    _gameManager.ShowUI(true);
                }
            }
            else
                _gameManager.HammerPower = 0;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _useAction.performed -= OnUse;
        }

       
    }
}