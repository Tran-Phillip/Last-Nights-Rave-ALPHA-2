using UnityEngine;
using System.Collections;

/*The main loop for the turn based battle system. 
Order goes:
|@prepPhase -> Prepares the encounter , pulls the monster data and party data. Only called once at the start of the encounter|
@startPhase -> The begining of the loop / turn, status effects and certain skills are called here
@actionPhase -> Player takes an action or the enemy takes an action 
@endPhase -> The turn ends and the next object's turn begins. Certain skills are called here
*/
public class BattleController : MonoBehaviour {
	//enums
	public enum BattleStates{prepPhase,startPhase,actionPhase,endPhase,nullPhase};
	public BattleStates currentState; //the current state the encounter is in.

	//bools
	public bool playerTurn; //true when the player can take an action, false when enemy's turn
	public bool enemyTurn; //true when the enemy can take an action, false when player's turn

	//static reference
	public static BattleController control;

	// Use this for initialization
	void Awake () 
	{
		if(control == null)
		{
			control = this;
		}
		else if(control != this)
		{
			Destroy(gameObject);
		}

		currentState = BattleStates.prepPhase;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentState == BattleStates.prepPhase)
		{
			prepPhase();
		}
		else if(currentState == BattleStates.startPhase)
		{
			startPhase();
		}
		else if(currentState == BattleStates.actionPhase)
		{
			actionPhase();
		}
		else if(currentState == BattleStates.endPhase)
		{
			endPhase();
		}
	}

	void prepPhase()
	{
		//enable the CreateBattleInstance script
		CreateBattleInstance instance;
		instance = GetComponent<CreateBattleInstance>();
		instance.enabled = true;
		currentState = BattleStates.nullPhase;

		//create the battle
		
		instance.CreateBattle();

	}
    void startPhase()
    {
        //do stuff
        currentState = BattleStates.actionPhase;
        print("The current turn is " + TurnController.instance.currentTurn.name);
        

    }
    void actionPhase()
    {
        //player takes their turn
    }
    void endPhase()
    {
        currentState = BattleStates.startPhase;
        TurnController.instance.endTurn();
    }






}
