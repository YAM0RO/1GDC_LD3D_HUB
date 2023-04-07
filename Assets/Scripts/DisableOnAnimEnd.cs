using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAnimEnd : MonoBehaviour
{
    void AnimEvent()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
}
