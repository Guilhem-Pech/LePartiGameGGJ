using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitNail : MonoBehaviour
{
    // Start is called before the first frame update
    private void CowSound()
    {
        AkSoundEngine.PostEvent("Flying_Cow", gameObject);
    }
}
