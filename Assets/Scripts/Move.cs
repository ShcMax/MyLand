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
       
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();        
    }
    public void MovementPlayer()
    {
        hInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(hInput, 0, 0);
        vInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, vInput);
    }
    public void Damage(int _damage)
    {
        changeHealth?.Invoke(_healthChange);
        _healthChange -= _damage;
    }
}
