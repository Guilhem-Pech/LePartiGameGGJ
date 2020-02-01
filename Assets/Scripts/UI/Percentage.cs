
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Percentage : MonoBehaviour
    {
        // Start is called before the first frame update
        private TextMeshProUGUI _percentage;
        private Tweener _options;
        private void Start()
        {
            _percentage = GetComponent<TextMeshProUGUI>();
            _options = DOTween.To(() => _percentage.text, x => _percentage.text = x, (0).ToString(), 0);
        }

        public void SetFixInt(int text)
        {
            _options?.Kill();
            _percentage.SetText(text.ToString() + "%");
        }
        public void SetInt(int text, int max = 25)
        {
            Debug.Log(text);
            if (text <= max)
            {
                _options?.Kill();
                _percentage.SetText(text.ToString() + "%");
            }
            else
            {
                if(!_options.IsActive())
                    _options = DOTween.To( ()=> _percentage.text, x=> _percentage.text = x, (text * 10000).ToString(), 100).SetOptions(false, ScrambleMode.Numerals).SetLoops(-1);
            }
        }
    }
}
