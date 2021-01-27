using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRot_Slider : MonoBehaviour
{
    Quaternion iniRot; 
    void Start()
    {
        iniRot = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = iniRot;
    }
}
