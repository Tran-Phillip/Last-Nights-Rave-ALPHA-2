using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FightButton : MonoBehaviour {

	//buttons
	public Button fightButton;

	//bools
	public bool isAttacking;

    //static reference
    public static FightButton instance;

  


	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	public void FightButtonClicked()
	{

      

		//tell the game you want to attack
		isAttacking = true;	

		//active the targeting controller
		TargetingController controller;
		controller = GetComponent<TargetingController>();
		controller.enabled = true;
		




	}


}
