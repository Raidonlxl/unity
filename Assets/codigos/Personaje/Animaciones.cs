using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    Player _player;
    public Animator anim;
    public float x;
    public float y;

    void Start()
    {
        _player = GetComponent<Player>();
         anim = GetComponent<Animator>();
    }

    void Update()
    {
        

    }
    public void RunAnim()
    {
        anim.SetFloat("velx", x);
  

    }
}
