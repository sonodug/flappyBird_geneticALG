using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x - _offsetX, transform.position.y, transform.position.z);   
    }
}
