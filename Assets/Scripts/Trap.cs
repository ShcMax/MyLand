using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int _damage = 1;
    private myGUI _healthPlayer;
    // Start is called before the first frame update
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _healthPlayer = other.GetComponent<myGUI>();
            _healthPlayer.DamageGui(_damage);
            Debug.Log(_healthPlayer.GUIHealth);
        }
    } 
}
