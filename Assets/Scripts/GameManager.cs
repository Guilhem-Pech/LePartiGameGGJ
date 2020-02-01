using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Animator _animator;
    [SerializeField]
    private PlayerInput _playerInput;
    
    [Header("Data to modify to tweak the values, made for the Game Designer")] public GameManagerData gameManagerData;

    [Header("Mainly for the developers")] 
    public TextMeshProUGUI hammerPowerDebug;
    public TextMeshProUGUI currentState;
    public Hammer hammerUI;


    public float HammerPower
    {
        get => _hammerPower;
        set
        {
            _hammerPower = value;
            if (hammerUI)
                hammerUI.FillLevel = Mathf.FloorToInt(value);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    public PlayerInput GetPlayerInput()
    {
        return _playerInput;
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

    public float GetTimerMinigameEnd()
    {
        return Random.Range(gameManagerData.minTimerMinigame, gameManagerData.maxTimerMinigame);
    }
}
