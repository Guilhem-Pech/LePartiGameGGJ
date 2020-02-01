using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;
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
    
    [Header("Mainly for the developers")] 
    public TextMeshProUGUI hammerPowerDebug;
    public TextMeshProUGUI currentState;
    public Hammer hammerUI;
    public Tweener hammerUIanim;
    public Image buttonImage;
    public Percentage percentage;
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

    public float NailProgress { get; set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        hammerUIanim = hammerUI.transform.DOShakePosition(1,5,10,90f,false,false).SetLoops(-1,LoopType.Yoyo).Pause();
    }

    public Sprite GetUseButtonSprite(InputDevice inputDevice)
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

    private void Update()
    {
        if(hammerPowerDebug)
            hammerPowerDebug.SetText(HammerPower.ToString("N"));
    }
    
    
    public Sprite GetSprite(string m)
    {
        return (from icon in buttonIcon where icon.Name == m select icon.sprite).FirstOrDefault();
    }
    
    public float GetTimerMinigameEnd()
    {
        return Random.Range(gameManagerData.minTimerMinigame, gameManagerData.maxTimerMinigame);
    }

    public void WitchDeviceWasUse(InputDevice controlDevice)
    {
        buttonImage.sprite = GetUseButtonSprite(controlDevice);
    }
}

[Serializable]
public class ButtonIcon
{
    public string Name;
    public Sprite sprite;

    
}