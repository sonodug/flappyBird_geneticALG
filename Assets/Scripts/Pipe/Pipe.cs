using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Transform _highY;
    [SerializeField] private Transform _bottomY;

    public Transform HighY => _highY;
    public Transform BottomY => _bottomY;
}
