using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private float vInput;
    private float hInput;
    public float moveSpeed;
    [SerializeField] Animator _anim;
    public int _state;

    private int _healthChange;

    public Action<int> changeHealth;
    public int PlayerHealth  {get => _healthChange; }
    public int PlayerMaxHealth => maxHealth;
    private void Awake()
    {
        _healthChange = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _state = 2;
            }
            else
            {
                _state = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _state = 3;
            }            
            if (Input.GetKey(KeyCode.D))
            {
                _state = 4;
            }           
        }
        else
        {
            _state = 0;
        }  
        _anim.SetInteger("State", _state);
    }    
    public void Damage(int _damage)
    {
        changeHealth?.Invoke(_healthChange);
        _healthChange -= _damage;
    }
}
