using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Screen_Rotate : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 25f;
    void Update()
    {
        transform.Rotate (0,0,_rotationSpeed*Time.deltaTime);
    }
}
