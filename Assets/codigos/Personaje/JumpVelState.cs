using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpVelState<T> : FSMstate<T>
{
   
    FSM<T> _fsm;
    T _idleInput;
    Rigidbody _rb;
    Player _player;
    public JumpVelState(FSM<T> fsm, T iI, Rigidbody rb,Player player) {

        _player = player;
        _idleInput = iI;
        _fsm = fsm;
        _rb = rb;
        

    }
    public override void awake()
    {
        _player.Jump();
    }
    public override void execute()
    {
        if (_rb.velocity.y==0)
        {
            _fsm.Transition(_idleInput);
        }
    }
}
