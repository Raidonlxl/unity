using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    //encapsular estado actual
    FSMstate<T> _current;
    //iniciar la FSM con un estado 
    public void setInit(FSMstate<T> init)
    {
        _current = init;
        _current.awake();
    }

    // actualizar el estados
    public void OnUpdate()
    {
        if (_current!= null)
        _current.execute();

    }
    //realiz la transicion
    public void Transition(T input)
    {
        //obtiene el estado a realizar
        FSMstate<T> newState = _current.GetTransition(input);
        //si no exciste transicion entre dos estados o no hay un estado, no hace la trancision
        if (newState == null)
        {
            return;
        }
        //realiza la salida
        _current.sleep();
        //entra el nuevo estado
        _current = newState;
        //ejecuta el nuevo estado
        newState.awake();
        

    }
}
