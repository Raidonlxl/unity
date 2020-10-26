using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate<T>
{
    //Entrar
    public virtual void awake() { }
    //ejecutar
    public virtual void execute() { }
    //se va
    public virtual void sleep() { }
    Dictionary<T, FSMstate<T>> _dic = new Dictionary<T, FSMstate<T>>();
    //agregar estados
    public void addTransition(T input,FSMstate<T>state)
    {
        if (!_dic.ContainsKey(input))
        {
            _dic.Add(input, state);
        } 

    }
    //remover estados
    public void RemoveTransition(T input)
    {
        if (_dic.ContainsKey(input))
        {
            _dic.Remove(input);
        }
    }
    //obtener estados
    public FSMstate<T> GetTransition(T input)
    {
        if (_dic.ContainsKey(input))
        {
            return _dic[input];
        }
        return null;
    }
}
