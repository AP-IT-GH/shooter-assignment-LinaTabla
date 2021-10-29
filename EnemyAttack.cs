using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    Vector3 hitPosition;

    void Update()
    {
        if (!FindTarget())
        {
            return;
        }
        InFront();
        HaveLineOfSightRayCast();
        if (InFront() && HaveLineOfSightRayCast())
        {
            FireLaser();
        }
    }

    bool InFront()
    {
        Vector3 directionRoTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionRoTarget);

        // if in range
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }
        return false;
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;

        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                hitPosition = hit.transform.position;
                return true;
            }
        }
        return true;
    }

    void FireLaser()
    {
        laser.FireLaser(hitPosition, target);
    }

    bool FindTarget()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (target == null)
        {
            return false;
        }
        return true;
    }
}
