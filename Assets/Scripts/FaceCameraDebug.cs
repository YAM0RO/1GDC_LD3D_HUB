using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraDebug : MonoBehaviour
{
    public Transform _target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(_target.position.x, transform.position.y, _target.position.z));
    }
}
