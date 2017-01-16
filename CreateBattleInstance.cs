using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class CreateBattleInstance : MonoBehaviour {
	//loads all the data from the databases for the turn based battle system

	// Json variables
	public string jsonString; //temperary string containing the JSON data
	public JsonData enemyDatabase; // contains all the enemy information of every encounter in the game
	public JsonData encounterData; //contains the current encounter's enemy data. 

	public JsonData partyDatabase; //contains the information of all the party members avaliable in the game
	public JsonData encounterParty; //contains the information of the party members in the encounter;

	//Lists 
	public List<EncounterObj> enemyList;
	public List<EncounterObj> partyList;

    
    


	//Arrays
	public GameObject[] enemies;
	public GameObject[] partyMembers;

	//static instance
	public static CreateBattleInstance instance;


	// Use this for initialization
	void Awake () 
	{
		
		instance = this;

		//creates the master enemy database
		jsonString = File.ReadAllText(Application.dataPath + "/Databases/enemyDatabase.json");
		enemyDatabase = JsonMapper.ToObject(jsonString);

		//creates the party member database
		jsonString = File.ReadAllText(Application.dataPath + "/Databases/character_database.json");
		partyDatabase = JsonMapper.ToObject(jsonString);

		//assigning the Lists
		enemyList = new List<EncounterObj>();
		partyList = new List<EncounterObj>();

		
		


		
		
	}
	
	public void CreateBattle()
	{
		//getting all the enemies
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		//adds the enemies to the encounter
		for(int i = 0; i < enemies.Length; i++)
		{
			string name = enemies[i].name;
			for(int j = 0; j < 3 ; j ++)
			{
				if(name == (string)enemyDatabase["enemy"][j]["name"])
				{
					enemyList.Add(new EncounterObj(i, enemies[i], (string) enemyDatabase["enemy"][j]["name"], (int) enemyDatabase["enemy"][j]["hp"], (int) enemyDatabase["enemy"][j]["str"], (int)enemyDatabase["enemy"][j]["dex"],
					 (int) enemyDatabase["enemy"][j]["int"], (int) enemyDatabase["enemy"][j]["agi"], (int) enemyDatabase["enemy"][j]["luck"], enemies[i].GetComponent<Animator>())); //seperate datatypes are fun.
				}
			}
		}
		

		//adds the party members to the encounter
		for(int i = 0; i < 2; i++) //FIXME: Add the party members depending on who is in the party
		{
			GameObject partyObj = GameObject.Find((string) partyDatabase["party"][i]["name"]);
		
			partyList.Add(new EncounterObj(i, partyObj, (string) partyDatabase["party"][i]["name"], (int) partyDatabase["party"][i]["hp"], 
				(int) partyDatabase["party"][i]["str"], (int) partyDatabase["party"][i]["dex"], (int) partyDatabase["party"][i]["int"], (int) partyDatabase["party"][i]["agi"],
				(int) partyDatabase["party"][i]["luk"], partyObj.GetComponent<Animator>()));
		
		}

		//creating the turn Queue 
		CreateTurnOrder instance;
		instance = GetComponent<CreateTurnOrder>();
		instance.enabled = true;
		instance.CreateTurnQueue(enemyList,partyList);

        //load the skill controller
        SkillListController control;
        control = GetComponent<SkillListController>();
        control.enabled = true;


	}




}
