using UnityEngine;
using System.Collections;

public class BattleComandController : MonoBehaviour {
    //Controls functions relating to player attacking, using a skill
    //using an item, fleeing, or guarding


    //Static Reference
    public static BattleComandController instance;


	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void BasicAttack(EncounterObj attacker, EncounterObj target)
    {
        //@attacker -> The object attacking
        //@target ->  the target being attacked
        //This function subtracts the target's health
        //by the attacker's str value.
        
        int damage = attacker.str;
        attacker.anim.SetTrigger("Attack");
        target.hp -= damage;
        EnemyInfoScript.instance.DisplayInfo(target);
        //end turn
    }
    
}
