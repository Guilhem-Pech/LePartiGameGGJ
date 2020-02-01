using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private PlayerInput _playerInput;

    [Header("Data to modify to tweak the values, made for the Game Designer")] public GameManagerData gameManagerData;

    public float HammerPower { get; set; } = 0f;
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
    
}
