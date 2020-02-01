using System;
using JetBrains.Annotations;
using  UnityEngine;
using UnityEngine.UI;

namespace UI
{
 public class FillHammer : MonoBehaviour
    {
        [NotNull] public Image fillBar;
        private int _fillLevel = 0;

        public int FillLevel
        {
            get => _fillLevel;
            set
            {
                fillBar.fillAmount = value / 30f;
            }
        }
        
        
    }
}