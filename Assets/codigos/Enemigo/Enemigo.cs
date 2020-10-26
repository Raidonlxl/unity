using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour,IMove
{
    public float poweJump = 10;
    public float speed = 2;

    public float rango;
    public float angulo;
    public LayerMask mask;
    public float anguloObjetivo;
    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
    }
    
    public bool teVeo(Transform target)
    {
        Vector3 diff = target.position - transform.position;
        float distancia = diff.magnitude;
        if (rango < distancia)
        {
            return false;
        }
        anguloObjetivo = Vector3.Angle(transform.forward, diff.normalized);
        if(anguloObjetivo > angulo / 2)
        {
            return false;
        }
        if (Physics.Raycast(transform.position, diff.normalized, distancia, mask))
        {
            return false;
        }
        return true;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * rango);
        Gizmos.DrawWireSphere(transform.position, rango);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angulo / 2, 0) * transform.forward * rango);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angulo / 2, 0) * transform.forward * rango);
    }

}
