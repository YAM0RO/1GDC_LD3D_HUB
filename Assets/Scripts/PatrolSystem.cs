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

    public bool IsPatrolling = true;

    void Start()
    {
        ReachedPointA = true;
        ReachedPointB = false;

        IsPatrolling = true;

        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPatrolling)
        {
            _nav.isStopped = false;
            if (ReachedPointA && !ReachedPointB)
            {
                _nav.SetDestination(PatrolB.position);
            }
            if (!ReachedPointA && ReachedPointB)
            {
                _nav.SetDestination(PatrolA.position);
            }
        }
        else if(!IsPatrolling)
        {
            _anim.SetBool("Walking", true);
            _nav.isStopped = true;
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

    public void RestorePatrol()
    {
        _anim.SetBool("Walking", false);
        IsPatrolling = true;
    }
}
