using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEarth : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);  
    }
}
