using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (GameManager.Instance.NailProgress >= 100f)
        {
            AkSoundEngine.PostEvent("Stop_Ambiance_calme", gameObject);
        }
    }

    void WooshSound()
    {
        AkSoundEngine.PostEvent("Woosh_Gros_Marteau", gameObject);
    }
    private void OnHitNail()
    {
        GameManager.Instance.onNailedHit.Invoke();

        AkSoundEngine.PostEvent("Nail", gameObject);
        if (GameManager.Instance.NailProgress >= 100f)
        {
            AkSoundEngine.PostEvent("Confirmation_Nail", gameObject);
        }
    }

    private void OnGameOver()
    {
        GameManager.Instance.OnGameOverEnd.Invoke();
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
        AkSoundEngine.PostEvent("Stop_Ambiance_calme", gameObject);
    }

    private void SparklesGameOver()
    {
        AkSoundEngine.PostEvent("Game_over_electric_sparkles", gameObject);
    }

    private void CreditsMusic()
    {
        AkSoundEngine.PostEvent("Play_Music", gameObject);
    }

    private void StopAmbiance()
    {
        AkSoundEngine.PostEvent("Stop_Ambiance_calme", gameObject);
    }

    private void NailIt()
    {
        AkSoundEngine.PostEvent("Voices/Nail_It", gameObject);
    }

    private void Explosion()
    {
        AkSoundEngine.PostEvent("Explosion", gameObject);
    }

    private void StartVibrate() => 
        Gamepad.current?.SetMotorSpeeds(0.8f,0.8f);

    private void EndExplosion() => 
        Gamepad.current?.SetMotorSpeeds(0f,0f);
}
