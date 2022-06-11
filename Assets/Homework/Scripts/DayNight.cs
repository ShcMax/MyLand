using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0, Space.Self);
    }
}
