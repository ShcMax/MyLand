using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_2 : MonoBehaviour
{
    [SerializeField] Animator _anim;
    float hInput;
    float vInput;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        
        _anim.SetFloat("Turn", vInput);        
        _anim.SetFloat("Move", hInput);
    }
}
