using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControllerISteering : MonoBehaviour
{
    public Transform target;
    public Rigidbody rbTarget;
    Enemigo _swat;
    public float timePrediction;
    ISteeringBehaviurs _sb;
    public float radius;
    public float avoidWeight;
    public LayerMask mask;
   
    void Start()
    {
        
        _swat = GetComponent<Enemigo>();
        //_sb = new  Persuit(target,transform,rbTarget,timePrediction);
        //_sb = new Evade(target, transform, rbTarget, timePrediction);
        _sb = new ObstacleAvoidance(transform, target, radius, avoidWeight,mask);

    }

    // Update is called once per frame
    void Update()
    {
        _swat.Move(_sb.GetDir());
    }
}
