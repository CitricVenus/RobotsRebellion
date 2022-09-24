using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol
{
    public string Value{
        get;
        private set;
    }

    public Symbol(string valued){
        Value = valued;
    }
}
