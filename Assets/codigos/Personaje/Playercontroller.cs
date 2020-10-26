using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Animator animator;
    Rigidbody _rb;
    FSM<string> _fsm;
    Player _player;
    Vector3 _dir = Vector3.zero;

    void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        //animator = GetComponent<Animator>();
        
        _fsm = new FSM<string>();
        IdleState<string> idle = new IdleState<string>(_fsm, "Move");
        MoveState<string> move = new MoveState<string>(_player,_fsm,"Jump","Idle");
        JumpVelState<string> jump = new JumpVelState<string>(_fsm, "Idle", _rb,_player);
        idle.addTransition("Move", move);
        move.addTransition("Idle", idle);
        move.addTransition("Jump", jump);
        jump.addTransition("Idle", idle);

        _fsm.setInit(idle);


    }

    public void transition(string input)
    {
        _fsm.Transition(input);
    }

    public void Update()
    {
       
        _fsm.OnUpdate();

    }
      
}
