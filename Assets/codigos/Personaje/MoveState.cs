using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : FSMstate<T>
{
    IMove entity;
    T _jumpInput;
    T _idleInput;
    FSM<T> _fsm;
    public MoveState(IMove e, FSM<T> fsm,T jumpInput,T IdleInput )
    {
        _jumpInput = jumpInput;
        _idleInput = IdleInput;
        _fsm = fsm;
        entity = e;
    }
    public override void execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 dir =new Vector3 (h,0,v);
        entity.Move(dir);
        if(h==0 && v == 0)
        {
            //realiza transicion
            _fsm.Transition(_idleInput);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //realiza transition
            _fsm.Transition(_jumpInput);
        }
    }
}
  
