using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTest : MonoBehaviour
{
    Rigidbody[] _rigid;
    Collider[] _coll;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigid = GetComponentsInChildren<Rigidbody>();
        _coll = GetComponentsInChildren<Collider>();

    }

    // Update is called once per frame
    private void RagdollActive(bool active)
    {
        foreach (var rig in _rigid)
        {
            rig.isKinematic = !active;

            if (active)
            {
                rig.AddForce(Vector3.forward * 2f, ForceMode.Impulse);
            }
        }

        foreach (var col in _coll)
        {
            col.enabled = active;
        }

        _rigid[0].isKinematic = active;
        _coll[0].enabled = !active;
    }

    public void End()
    {
        RagdollActive(true);
        _anim.enabled = false;
    }    
}
