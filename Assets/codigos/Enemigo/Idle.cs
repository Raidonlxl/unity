using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle<T> : FSMstate<T>
{
    
    Transform _target;
    Transform _propio;
    EnemigoController _enemigoController;
    FSM<T> _fsm;
    T _patrol;
    T _persuit;
    IMove _entity;
     public float  tiempo=1;
    public float tiempoSeg;
    public float maximo =6;

    public Idle(IMove entity, Transform target, EnemigoController enemigoController, FSM<T> fsm, T patrol)
    {
        _target = target;
        _propio = enemigoController.transform;
        _enemigoController = enemigoController;
        _fsm = fsm;
        _patrol = patrol;
        _entity = entity;
    }
    public override void awake()
    {
        base.awake();
    }
    public override void execute()
    {
        

        var dir = (_propio.position*0);
        _entity.Move(dir);
        if (!_enemigoController.teVeo)
        {
            PasaElTiempo();
            if (tiempo==maximo) _fsm.Transition(_patrol);
        }
      

        
    }
    public override void sleep()
    {
        base.sleep();
    }

    public void PasaElTiempo()
    {
        //esperar N (tiempo) Segundos
        tiempoSeg += Time.deltaTime;
        if ((tiempoSeg >= tiempo) && tiempo < maximo)
        {
            tiempoSeg = 0;
            tiempo++;
        }
        Debug.Log(tiempo);

    }
}
