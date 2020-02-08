using DG.Tweening;
using UI;
using UnityEngine;

namespace States
{
    public class OnPerfect : StateMachineBehaviour
    {
        private static readonly int PrevState = Animator.StringToHash("PrevState");
        private static readonly int NextState = Animator.StringToHash("NextState");
        private static readonly int Stop = Animator.StringToHash("Stop");
        private static readonly int PreventRestart = Animator.StringToHash("PreventRestart");
        private NailPopup _nailPopup;
        private Animator _animator;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _nailPopup = GameManager.Instance.nailPopup;
            _animator = animator;
            GameManager.Instance.currentState.SetText("YOU NAILED IT");
            GameManager.Instance.onSuccessEvent.Invoke();
            GameManager.Instance.onNailedHit.AddListener(OnNailedHit);
            _nailPopup.gameObject.SetActive(true);
            _nailPopup.text.text = $"{GameManager.Instance.NailProgress}%";
            _nailPopup.text.DOFade(1, 0.2f);
            _nailPopup.image.DOFade(1, 0.2f);
            _nailPopup.text.text = $"{GameManager.Instance.NailProgress}";
            Timer.Register(GameManager.Instance.gameManagerData.successTime,OnComplete);
            GameManager.Instance.ShowUI(false);
            GameManager.Instance.backgroundAnimator.SetTrigger(Stop);
            GameManager.Instance.backgroundAnimator.SetBool(PreventRestart,true);
            GameManager.Instance.ShowUIButton(false);
        }

        private void OnNailedHit()
        {
            int text = GameManager.Instance.NailProgress;
            
            GameManager.Instance.NailProgress += (int) GameManager.Instance.HammerPower > 24
                ? 25
                : (int) GameManager.Instance.HammerPower;

            DOTween.To(() => text, value => text = value, GameManager.Instance.NailProgress, 0.6f).OnUpdate(() =>
            {
                _nailPopup.text.text = $"{text}%";
            }); 

        }


        private void OnComplete()
        {
            _animator.SetTrigger(GameManager.Instance.NailProgress < 100 ? PrevState : NextState);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _nailPopup.image.DOFade(0, 0.5f);
            _nailPopup.text.DOFade(0, 0.5f);

            _nailPopup.gameObject.SetActive(false);

            GameManager.Instance.HammerPower = 0f;
            GameManager.Instance.backgroundAnimator.SetBool(PreventRestart,false);
            GameManager.Instance.onNailedHit.RemoveListener(OnNailedHit);
        }

    }
}