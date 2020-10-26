using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState<T> : FSMstate<T>
{
    Transform _npc;
    Transform _target;
    Rigidbody _rbTarget;
    public float timePrediction;
    public EvadeState(Transform npc,Transform target,Rigidbody rb,float timePrediction)
    {
        _target = target;
        _npc = npc;
        _rbTarget = rb;
    }

    public override void awake()
    {
       
    }
    public override void execute()
    {
        GetDir();
    }

    public Vector3 GetDir()
    {
        Vector3 posPrediction = _target.position + timePrediction * _rbTarget.velocity.magnitude * _target.forward;
        Vector3 dir = (_npc.position - posPrediction).normalized;
        return dir;
    }

}
