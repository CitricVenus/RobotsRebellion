using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    //States
    State basic,fourFires,shoot360,multiply,shootFire;

    //Symbols
    Symbol señal1,señal2,señal3,señal4;

    //initial state
    State current;
    MonoBehaviour currentBehaviour;
    //public VidaBoss bossLife;
    public static int vencidos;
    public Animator animator;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        once = true;

        basic = new State("Basico",typeof(Basico));
        fourFires = new State("Cuatro Fuegos",typeof(CuatroFuegos));
        shoot360 = new State("Dispara 360",typeof(Shoot360));
        multiply = new State("Division",typeof(MultiplynShoot));
        shootFire = new State("Dispara fuego",typeof(DisparaFuego));

        señal1 = new Symbol("Señal1");
        señal2 = new Symbol("Señal2");
        señal3 = new Symbol("Señal3");
        señal4 = new Symbol("Señal4");

        //Set transitions
        basic.AddTransition(señal1,shootFire);
        shootFire.AddTransition(señal2,fourFires);
        fourFires.AddTransition(señal3,multiply);
        multiply.AddTransition(señal4,shoot360);

        //Set initial state
        current = basic;

        //Add behaviour
        gameObject.AddComponent<Basico>();
        //gameObject.AddComponent(typeof(PelearBehaviour));
    }

    void changeState(Symbol symbol){
        State newState = current.ApplySymbol(symbol);
        changeState(newState);
    }

    void changeState(State newState){
        if(current == newState)
            return;
        if(current != null && currentBehaviour != null){
            Destroy(currentBehaviour);
        }
        current = newState;
        currentBehaviour = gameObject.AddComponent(current.Behaviour) as MonoBehaviour;
    }

    // Update is called once per frame
    void Update(){   
        if(VidaBoss.vidaBoss ==89 && once)
            changeState(señal1);
             animator.SetBool("stop",true);
        if(VidaBoss.vidaBoss ==69 && once)
            changeState(señal2);
            animator.SetBool("stop",true);
        if(VidaBoss.vidaBoss ==39 && once){
            changeState(señal3);
            animator.SetBool("stop",true);
            once = false;
        }
        if(!once && vencidos == 4){
            changeState(señal4);
        }
    }

}
