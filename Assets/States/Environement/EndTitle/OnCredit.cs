using UnityEngine;

namespace States.Environement.EndTitle
{
    public class OnCredit : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AkSoundEngine.PostEvent("Stop_Ambiance_Calme", null);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Application.Quit();
        }
    }
}