using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_2 : MonoBehaviour
{
    [SerializeField] Animator _anim;
    Rigidbody _rig;
    float hInput;
    float vInput;
    float mouseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        //Vector3 dir = new Vector3(vInput, 0, hInput);       

        //_anim.SetFloat("Move", Vector3.ClampMagnitude(dir, 1).magnitude);
        //_rig.velocity = Vector3.ClampMagnitude(dir, 1) * speed;
        _anim.SetFloat("Move", vInput);
        _anim.SetFloat("Turn", hInput);

        float mouseTurn = Input.GetAxis("Mouse X");
        mouseSpeed = Mathf.Lerp(mouseSpeed, mouseTurn, 20 * Time.deltaTime);
        _anim.SetFloat("MouseTurn", mouseSpeed);
    }

}
