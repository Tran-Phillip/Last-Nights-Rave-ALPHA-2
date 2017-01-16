using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CreateTurnOrder : MonoBehaviour {
	//creates the turn order Queue for the battle system

	//Queues
	public Queue<EncounterObj> turnOrder;

	//List
	public List<EncounterObj> combinedList; //combination of the party and enemy list

	//static instance
	public static CreateTurnOrder instance;

	// Use this for initialization
	void Awake () {
		instance = this;

		combinedList = new List<EncounterObj>();
		turnOrder = new Queue<EncounterObj>();
	}
	void Update()
	{
		
	}
	
	public void CreateTurnQueue(List<EncounterObj> enemyList, List<EncounterObj> partyList)
	{	
		/*
		@enemyList -> List of enemies in the encounter
		@partyList -> List of party members in the encounter
		This function combined the two list made in CreateBattleInstance 
		into one list, then sorts the values based on the "agi" stat.
		The function then adds them to a queue.
		*/

		foreach(EncounterObj enemy in enemyList)
		{
			combinedList.Add(enemy);
		}

		foreach(EncounterObj partyMem in partyList)
		{
			combinedList.Add(partyMem);
		}

		combinedList.Sort();

		
		foreach(EncounterObj member in combinedList)
		{
			turnOrder.Enqueue(member);
		}
        //Turn on the Turn Controller
        TurnController control = GetComponent<TurnController>();
        control.enabled = true;

		
	}
}
