using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir<T> :FSMstate<T>

    {
    IMove _entidad;
    FSM<T> _fsm;
    public float velocidad;
    Transform _target;
    Transform _propio;
    EnemigoController _enemController;
    
    T _patrol;

    public Perseguir(IMove entidad, FSM<T> fsm, Transform target,EnemigoController enemController,T patrol )
    {
        _entidad = entidad;
        _fsm = fsm;
        _target = target;
        _propio = enemController.transform;
        _enemController = enemController;
        _patrol = patrol;
    }
    void Start()
    {
        
        
    }

    public override void awake()
    {
        base.awake();
    }
    public override void execute()
    {
        
        var dir = (_target.position - _propio.position).normalized;
        _entidad.Move(dir);
        //!  = pregunto si es falso./sin signo verdadero
        if (!_enemController.teVeo)
        {
            _fsm.Transition(_patrol);
        }
              
          

        
    }
    public override void sleep()
    {
        base.sleep();
    }

}
