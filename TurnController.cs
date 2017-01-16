using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : MonoBehaviour {
    //Functions related to ending or keeping track of the turn

    //GameObjects
    public EncounterObj currentTurn;

    //Queues
    public Queue<EncounterObj> turnQueue;

    //static reference
    public static TurnController instance;

	// Use this for initialization
   

	void Start () {
        instance = this;
        
        //Get the turn Queue
        turnQueue = CreateTurnOrder.instance.turnOrder;
        currentTurn = turnQueue.Peek(); 

        //Start the battle!!
        BattleController.control.currentState = BattleController.BattleStates.startPhase;

    }
	
	// Update is called once per frame
	void Update () {
        //Keep track of the current turn
        currentTurn = turnQueue.Peek();
	}
    public void endTurn()
    {
        EncounterObj previousTurn = turnQueue.Dequeue();
        //move the pointer to UI element for turn
        turnQueue.Enqueue(previousTurn);

        
      

    }
}
