using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetingController : MonoBehaviour {
	/*Functions pertaining to selecting targets, selecting multiple targets,
		or deselecting targets */

	//ints
	public int index = 0; //Controls what target in the list you're attacking.

	//Bools
	public bool singleTarget;

	//List 
	public List<EncounterObj> enemyList;

	//static instance
	public static TargetingController instance; 


	// Use this for initialization
	void Start () {		
		instance = this;

		
		
	}
    
    void OnEnable()
    {
        //Get the enemy List
        enemyList = CreateBattleInstance.instance.enemyList;

        //targets a single enemy at index 0
        TargetSingle(enemyList[index].obj);

        //Moves the textbox to that enemy at that index
        EnemyInfoScript.instance.CreateEnemyInfoBox(enemyList[index]); 
    }
	
	// Update is called once per frame
	void Update () {
		/*Update in this function controls the movement
		of the targeting icon*/


		//cancel the targeting
		if(Input.GetButtonDown("Cancel") && singleTarget == true)
		{
			//tell the game you no longer want to select a target
			singleTarget = false;

            //tell the game you are not longer attacking 
            FightButton.instance.isAttacking = false;

			//destroy all the selectors
			CreateSelector.instance.DestroySelector();
            this.enabled = false;

            //destroy the info box
            EnemyInfoScript.instance.DestroyInfoBox();
		}

        //select different targets
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            index = index - 1;
            if ((index) < 0)
            {
                index = enemyList.Count - 1; //if it tries to access an index that does not exist, loop around to the last entry
            }
            EnemyInfoScript.instance.MoveInfoBox(enemyList[index]); //Moves the information box along with the targeting cursor
            TargetSingle(enemyList[index].obj);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            index = index + 1;
            if ((index) >= enemyList.Count)
            {
                index = 0; //if it tries to access an index that does not exist, loop around to the last entry
            }
            EnemyInfoScript.instance.MoveInfoBox(enemyList[index]);
            TargetSingle(enemyList[index].obj);
        }
        else if (Input.GetButtonDown("Confirm") && FightButton.instance.isAttacking) //Using the attack command with a character
        {
            BattleComandController.instance.BasicAttack(TurnController.instance.currentTurn, enemyList[index]);
            FightButton.instance.isAttacking = false;
            BattleController.control.currentState = BattleController.BattleStates.endPhase;
        }
	}

	public void TargetSingle(GameObject target)
	{
		//tell the game you are targeting a single enemy
		singleTarget = true;

		//move selector position to that enemy
		CreateSelector.instance.MoveSelector(new Vector3(target.transform.position.x , target.transform.position.y, target.transform.position.z));
	}

}
