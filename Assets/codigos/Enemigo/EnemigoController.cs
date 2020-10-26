using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public bool teVeo;
    public List<Transform> waypoints;
    FSM<string> _fsm;
    Rigidbody _rb;
    Enemigo _swat;
    public Player _player;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _swat = GetComponent<Enemigo>();
        _fsm = new FSM<string>();
      
        
        Patrol<string> patrol = new Patrol<string>(_swat,waypoints,this,_fsm,"persuit");
        Perseguir<string> persuit = new Perseguir<string>(_swat, _fsm, _player.transform,this,"patrol");
        Idle<string> idle = new Idle<string>(_swat, _player.transform, this, _fsm, "patrol");
        patrol.addTransition("persuit", persuit);
        persuit.addTransition("patrol", patrol);
        idle.addTransition("patrol", patrol);

        _fsm.setInit(idle);
       
    }
    private void Update()
    {
        _fsm.OnUpdate();

        LineOfSight();


    }

    public void LineOfSight()
    {
        if (_swat.teVeo(_player.transform))
        {
            teVeo = true;
            
        }
        else
        {
            teVeo = false;
       
        }


    }

}
