using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSystem : MonoBehaviour
{
    public Transform PatrolA;
    public Transform PatrolB;

    private NavMeshAgent _nav;
    private Animator _anim;

    private bool ReachedPointA = true;
    private bool ReachedPointB = false;
    void Start()
    {
        ReachedPointA = true;
        ReachedPointB = false;

        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ReachedPointA && !ReachedPointB)
        {
            _nav.SetDestination(PatrolB.position);
        }
        if(!ReachedPointA && ReachedPointB)
        {
            _nav.SetDestination(PatrolA.position);
        }
    }

    public void HaveReachA()
    {
        ReachedPointA = true;
        ReachedPointB = false;
    }

    public void HaveReachB()
    {
        ReachedPointA = false;
        ReachedPointB = true;
    }
}
