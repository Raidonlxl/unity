using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol<T> : FSMstate<T>
{
    public List<Transform> waypoints;
    public float distance = 5;
    public int _nextPoint;
    public int _indexModifier = 1;
    Enemigo _swat;
    Player player;
    public Transform _target;
    EnemigoController _enemController;
    FSM<T> _fsm;
    T _Persuit;
   
    public Patrol(Enemigo enemy, List<Transform> Way,EnemigoController enemController, FSM<T> fsm, T persuit)
    {
        _swat = enemy;
        waypoints = Way;
        _enemController = enemController;
        _fsm = fsm;
        _Persuit = persuit;
    }

    public override void awake()
    {
       
    }
    public override void execute()
    {
        
        var point = waypoints[_nextPoint];
        var posPoint = point.position;
        posPoint.y = _swat.transform.position.y;
        Vector3 dir = posPoint - _swat.transform.position;
        
        if (dir.magnitude < distance)
        {
            if (_nextPoint + _indexModifier >= waypoints.Count || _nextPoint + _indexModifier < 0)
                _indexModifier *= -1;
            _nextPoint += _indexModifier;
            

        }
        
        _swat.Move(dir.normalized);

        if (_enemController.teVeo)
        {
            _fsm.Transition(_Persuit);
        }
       
    }
}
