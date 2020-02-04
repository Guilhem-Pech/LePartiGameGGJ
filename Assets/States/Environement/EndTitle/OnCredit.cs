using UnityEngine;

namespace States.Environement.EndTitle
{
    public class OnCredit : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Application.Quit();
        }
    }
}