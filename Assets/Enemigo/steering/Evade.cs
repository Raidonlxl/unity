using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : ISteeringBehaviurs
{
    Transform _npc;
    Rigidbody _rbTarget;
    public float timePrediction;
    Transform _target;
    public Evade(Transform target,Transform npc,Rigidbody rb,float time)
    {
        _npc = npc;
        _rbTarget = rb;
        _target = target;
        timePrediction = time;

    }
    public Vector3 GetDir()
    {
        Vector3 posPrediction =_target.position + timePrediction * _rbTarget.velocity.magnitude * _target.forward;
        Vector3 dir = (_npc.position - posPrediction).normalized;
        return dir; 
    }
   
}
