using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMouse : MonoBehaviour
{
    public bool LockMouse;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
