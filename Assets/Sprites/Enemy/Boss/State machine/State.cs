using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State
{
    public string Name{
        get;
        private set;
    }

    public Type Behaviour {
        get;
        private set;
    }

    private Dictionary<Symbol,State> transition;

    public State(string name, Type behaviour){
        Name = name;
        transition = new Dictionary<Symbol, State>();
        Behaviour = behaviour;
    }

    public void AddTransition(Symbol key, State value){
        transition.Add(key,value);
    }

    public State ApplySymbol(Symbol key){
        if(!transition.ContainsKey(key))
            return this;
        
        return transition[key];
    }
}
