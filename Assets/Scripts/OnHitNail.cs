using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitNail : MonoBehaviour
{
    
    public AK.Wwise.Event thunderEvent;
    // Start is called before the first frame update
    private void CowSound()
    {
        AkSoundEngine.PostEvent("Flying_Cow", gameObject);
    }
    
    private void OnThunder()
    {
        thunderEvent.Post(gameObject);
    }
}
