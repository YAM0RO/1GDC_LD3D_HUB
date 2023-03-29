using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadIK : MonoBehaviour
{
    private Animator _anim;
    public bool ActiveIK = false;
    public Transform Target;
    public float lookWeight;
    public float desireDist;

    public GameObject objectPivot;
    void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        objectPivot.transform.LookAt(Target);
        float pivotRotY = objectPivot.transform.localRotation.y;

        float dist = Vector3.Distance(objectPivot.transform.position, Target.position);

        if(pivotRotY < 0.65f && pivotRotY > -0.65f && dist < desireDist)
        {
            lookWeight = Mathf.Lerp(lookWeight, 1, Time.deltaTime * 2.5f);
        }
        else
        {
            lookWeight = Mathf.Lerp(lookWeight, 0, Time.deltaTime * 2.5f);
        }
    }

    private void OnAnimatorIK()
    {
        if(_anim)
        {
            if(ActiveIK)
            {
                if(Target != null)
                {
                    _anim.SetLookAtWeight(lookWeight);
                    _anim.SetLookAtPosition(Target.position);
                }
            }

            else
            {
                _anim.SetLookAtWeight(0);
            }
        }
    }
}
