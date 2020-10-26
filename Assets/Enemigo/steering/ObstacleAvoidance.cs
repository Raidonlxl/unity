using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : ISteeringBehaviurs
{

    public Transform _npc;
    public Transform _target;
    public float radius;
    public LayerMask _mask;
    public float _avoidWeight;
    public ObstacleAvoidance(Transform npc, Transform target, float radius,float avoidWeight, LayerMask mask)
    {

        _avoidWeight = avoidWeight;
        _npc = npc;
        _target = target;
        _mask = mask;
        this.radius = radius;

    }
    public Vector3 GetDir()
    {  
       Collider[] obstacles = Physics.OverlapSphere(_npc.position, radius, _mask);
        Transform obsSave = null;
        var count = obstacles.Length;
        for (int i = 0; i < count; i++)
        {
            var currObs = obstacles[i].transform;
            if (obsSave == null)
            {
                obsSave = currObs;
            }
            else if (Vector3.Distance(_npc.position,obsSave.position)> Vector3.Distance(_npc.position,currObs.position))
            {
                obsSave = currObs;
            }

        }
        var dirToTarget = (_target.position - _npc.position).normalized;
        if(obsSave != null)
        {
            Vector3 dirObsToNpc = (_npc.position - obsSave.position).normalized * _avoidWeight;
            dirToTarget += dirObsToNpc;

        }
        return dirToTarget.normalized;
        }
}

