using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Target;
    private void Update()
    {


        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z - 9.8f;
        transform.position = transformPosition ;
    }
}
