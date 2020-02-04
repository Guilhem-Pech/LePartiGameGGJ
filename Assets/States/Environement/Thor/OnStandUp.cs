using UnityEngine;

namespace States.Environement.Thor
{
    public class OnStandUp : StateMachineBehaviour
    {

        private GameManager _gameManager;
        private static readonly int PrevState = Animator.StringToHash("PrevState");
        private static readonly int NextState = Animator.StringToHash("NextState");
      
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _gameManager = GameManager.Instance;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(_gameManager.HammerPower <= 0f) animator.SetTrigger(PrevState);
            if(_gameManager.HammerPower >= _gameManager.gameManagerData.minHammerPowerEnteringMinigame) animator.SetTrigger(NextState);
            
        }
    }
}