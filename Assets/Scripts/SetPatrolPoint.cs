using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPatrolPoint : MonoBehaviour
{
    public bool IsPointA;
    public bool IsPointB;
    public PatrolSystem _patrolNPC;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("npc"))
        {
            if(IsPointA)
            {
                _patrolNPC.HaveReachA();
                Debug.Log("Point A !");
            }

            if (IsPointB)
            {
                _patrolNPC.HaveReachB();
                Debug.Log("Point B !");
            }
        }
    }
}
