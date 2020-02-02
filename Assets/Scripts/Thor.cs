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
}
