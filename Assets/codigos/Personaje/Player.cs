using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMove
{
    public float poweJump;
    public float speed;
    Rigidbody _rb;
    Playercontroller _playercontroller;
    Animaciones _playerAnimation;
   
    private void Awake()
    {
        _rb=GetComponent<Rigidbody>();
        _playercontroller = GetComponent<Playercontroller>();
        _playerAnimation = GetComponent<Animaciones>();

    }
    public void Move(Vector3 dir)
    {
         dir.y =0;
        _rb.velocity = dir * speed;
        transform.forward = dir;
        
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * poweJump, ForceMode.Impulse);
    }
}