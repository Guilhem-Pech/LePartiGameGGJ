using UnityEngine;

namespace UI
{
    public class Hammer : MonoBehaviour
    {
        public Thunderbolts thunderbolt;
        public FillHammer fillHammer;
        
        public int FillLevel
        {
            get => Mathf.FloorToInt(GameManager.Instance.HammerPower * 100);
            set => SetFillLevel(value);
        }

        private void SetFillLevel(int level)
        {
            fillHammer.FillLevel = level;
            thunderbolt.FillLevel = level;
        }
    }
}