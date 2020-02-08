using System;
using System.Linq;
using Data;
using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Animator _animator;
    [SerializeField]
    private PlayerInput playerInput;
    
    [Header("Data to modify to tweak the values, made for the Game Designer")] public GameManagerData gameManagerData;
    public ButtonIcon[] buttonIcon;
    public NailPopup nailPopup;
    
    [Header("Mainly for the developers")] 
    public TextMeshProUGUI hammerPowerDebug;
    public TextMeshProUGUI currentState;
    public Hammer hammerUI;
    public Tweener hammerUIanim;
    public Image buttonImage;
    public Percentage percentage;
    public Animator backgroundAnimator;
    public Animator thorAnimator;
    public CanvasGroup canvasUIHammer;
    public CanvasGroup canvasUIButton;
    [HideInInspector] public UnityEvent onFailedEvent;
    [HideInInspector] public UnityEvent onSuccessEvent;
    [HideInInspector] public UnityEvent OnGameOverEnd;
    [HideInInspector] public UnityEvent onNailedHit;
    public Transform nailTransform;
    public CanvasGroup title;
    public GamepadVibrate gamepadVibrate;
    public GameObject endScreen;
    public float HammerPower
    {
        get => _hammerPower;
        set
        {
            _hammerPower = value;
            int p = Mathf.FloorToInt(value);
            if (hammerUI)
                hammerUI.FillLevel = p;
            if (percentage) percentage.SetInt(p);
            if (value > gameManagerData.shakeMin && !hammerUIanim.IsPlaying())
                hammerUIanim.Play();
            else if (value <= gameManagerData.shakeMin && hammerUIanim.IsActive())
                hammerUIanim.Pause();
        }
    }

    public int NailProgress
    {
        get
        {
            Debug.Log("NAIL PROGRESS: " + _nailProgress);
            return _nailProgress;
        } 
        set
        {
            _nailProgress = Mathf.Clamp(value,0,100);
            nailTransform.DOLocalMove(new Vector3(0,-(value / 100f),0), 0.3f);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        hammerUIanim = hammerUI.transform.DOShakePosition(1,5,10,90f,false,false).SetLoops(-1,LoopType.Yoyo).Pause();
    }

    private RuntimeAnimatorController GetUseButtonSprite(InputDevice inputDevice)
    {
        switch (inputDevice)
        {
            case Keyboard _:
                return GetSprite("PC");
            case DualShockGamepad _:
                return GetSprite("PS4");
            case XInputControllerWindows _:
                return GetSprite("XBox");
            case Gamepad _:
                return GetSprite("PS4"); 
            default:
                return GetSprite("PC");
        }
    }
    
    
    
    
    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }


    private void Awake()
    {
       if(Instance != null && Instance != this)
           Destroy(gameObject);
       else  Instance = this;
    }

    private float _hammerPower;
    private int _nailProgress;


    private void Update()
    {
        if(hammerPowerDebug)
            hammerPowerDebug.SetText(HammerPower.ToString("N"));
    }


    private RuntimeAnimatorController GetSprite(string m)
    {
        return (from icon in buttonIcon where icon.Name == m select icon.sprite).FirstOrDefault();
    }
    
    public float GetTimerMinigameEnd()
    {
        return Random.Range(gameManagerData.minTimerMinigame, gameManagerData.maxTimerMinigame);
    }

    public void WitchDeviceWasUse(InputDevice controlDevice)
    {
        buttonImage.gameObject.GetComponent<Animator>().runtimeAnimatorController = GetUseButtonSprite(controlDevice);
    }

    public void ShowUI(bool show = true)
    {
        if (show)
        {
            DOTween.To(() => canvasUIHammer.alpha, value => canvasUIHammer.alpha = value, 1, 1);
            DOTween.To(() => title.alpha, value => title.alpha = value, 0, 1);
        }
        else
        {
            canvasUIHammer.alpha = 0;
        }
    }
    
    public void ShowUIButton(bool show = true)
    {
        float endValue = show ? 1f : 0f;
        //DOTween.To(() => canvasUIButton.alpha, value => canvasUIButton.alpha = value, endValue, 1);
        canvasUIButton.alpha = endValue;
    }
}

[Serializable]
public class ButtonIcon
{
    public string Name;
    public RuntimeAnimatorController sprite;

    
}