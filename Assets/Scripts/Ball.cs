using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private int _direction = 0;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }
}
