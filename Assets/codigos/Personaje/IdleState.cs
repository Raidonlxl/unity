using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : FSMstate<T>
{
    FSM<T>_fsm;
    T _moveImput;
    public IdleState(FSM<T> fsm, T mI)
    {
        _fsm = fsm;
        _moveImput = mI;
    }
    public override void execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        if (h!= 0 || v!= 0)
        {
            _fsm.Transition(_moveImput);
        }
    }
    public override void awake()
    {
     
    }
    public override void sleep()
    {
        
    }
    
}
