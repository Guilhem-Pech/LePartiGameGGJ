using UnityEngine;

namespace Data
{
    [UnityEngine.CreateAssetMenu(fileName = "GameManagerData", menuName = "Create gamemanager data", order = 0)]
    public class GameManagerData : UnityEngine.ScriptableObject
    {
        [Tooltip("Force added when you smash the button in the idle/raising state")] public float idleAddForce = 2f ;
        public float decreasePowerPerSecond = 1f;
        public float minHammerPowerEnteringMinigame = 10f;
        [Tooltip("Force added when you smash the button in a minigame")] public float smashAddForce = 2f;
        public float thresholdReturnToIdle = 8f;
        public float minTimerMinigame = 5f;
        public float maxTimerMinigame = 7f;
        public float kaboomThreshold = 25f;
        public int levelOneThunderbolt = 10;
        public int levelTwoThunderbolt = 20;
        public int levelThreeThunderbolt = 26;
    }
}