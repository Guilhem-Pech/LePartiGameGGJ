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
        
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _animator = animator;
            _gameManager = GameManager.Instance;
            _useAction =  _gameManager.GetPlayerInput().actions.FindAction("Use");
            _useAction.performed += OnUse;
        
        }

        private void OnUse(InputAction.CallbackContext arg0)
        {
            // If A is pressed, raise hand !
            _animator.SetTrigger(NextState);
            _gameManager.HammerPower += 2;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _useAction.performed -= OnUse;
        }
    }
}