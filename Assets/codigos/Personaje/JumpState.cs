using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState<T>: FSMstate<T>
{
    Transform _objet;
    float _distance;
    LayerMask _mask;
    FSM<T> _fsm;
    T _idleInput;
    public JumpState(FSM<T> fsm,T iI, Transform obj,float distance, LayerMask mask)
    {
        _idleInput = iI;
        _fsm = fsm;
        _objet=obj;
        _distance = distance;
        _mask = mask;

    }
    public override void execute()
    {
        if (Physics.Raycast(_objet.transform.position, Vector3.down, _mask))
        {
            _fsm.Transition(_idleInput);
        }
    }
}
