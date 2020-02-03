using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thor : MonoBehaviour
{
    private static readonly int NextState = Animator.StringToHash("NextState");
    private static readonly int LowerHammer = Animator.StringToHash("LowerHammer");

    // Start is called before the first frame update
    private void OnFailedAnimEnded()
    {
        GameManager.Instance.thorAnimator.SetTrigger(NextState);
    }

    private void OnSuccessAnimEnded()
    {
        GameManager.Instance.thorAnimator.SetTrigger(
            GameManager.Instance.NailProgress >= 100f ? NextState : LowerHammer);
    }

    void WooshSound()
    {
        AkSoundEngine.PostEvent("Woosh_Gros_Marteau", gameObject);
    }
    private void OnHitNail()
    {
        AkSoundEngine.PostEvent("Nail", gameObject);
    }

    private void PlayMarteauIdleSound()
    {
        AkSoundEngine.PostEvent("Play_Charge_Marteau_Loop", gameObject);

    }
    
    private void StopMarteauIdleSound()
    {
        AkSoundEngine.PostEvent("Stop_Charge_Marteau_Loop", gameObject);

    }

    private void ConfirmationNail()
    {
        AkSoundEngine.PostEvent("Confirmation_Nail", gameObject);
    }

    private void SparklesGameOver()
    {
        AkSoundEngine.PostEvent("Game_over_electric_sparkles", gameObject);
    }
    
    private void Explosion()
    {
        AkSoundEngine.PostEvent("Explosion", gameObject);
    }
}
