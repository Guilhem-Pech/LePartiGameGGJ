
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Percentage : MonoBehaviour
    {
        // Start is called before the first frame update
        private TextMeshProUGUI _percentage;
        private Tweener _options;
        public Image[] fillBar;

        private void Start()
        {
            _percentage = GetComponent<TextMeshProUGUI>();
            _options = DOTween.To(() => _percentage.text, x => _percentage.text = x, (0).ToString(), 0);
        }

        private static readonly Color Red = new Color(220/255f,0,50/255f);
        private static readonly Color Green = new Color(40/255f,200/255f,0);
        private static readonly Color Green_2 = new Color(40/255f,200/255f,0.6f);
        private static  readonly Color Blue = new Color(40/255f,200/255f,255/255f);

        private void SetImgColor(Color color)
        {
            foreach (Image image in fillBar) image.color = color;
        }
        
        private static Color GetColor(int percent)
        {
            if (percent > 25)
                return Red;
            if(percent > 20)
                return Green;
            if (percent > 10)
                return Color.LerpUnclamped(Blue, Green_2, (percent - 10)/5f);
            return Blue;
        }
        
        public void SetFixInt(int text)
        {
            _options?.Kill();
            _percentage.SetText(text + "%");
            Color c = GetColor(text);
            _percentage.color = c;
            SetImgColor(c);
        }
        public void SetInt(int text, int max = 25)
        {
            if (text <= max)
                SetFixInt(text);
            else if (!_options.IsActive())
            {
                _options = DOTween.To(() => _percentage.text, x => _percentage.text = x, (text * 10000).ToString(), 100)
                    .SetOptions(false, ScrambleMode.Numerals).SetLoops(-1);
                Color c = GetColor(text);
                _percentage.color = c;
                SetImgColor(c);
            }
        }
    }
}
