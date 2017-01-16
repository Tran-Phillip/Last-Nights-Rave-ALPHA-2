using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillListController : MonoBehaviour {
    //This function creates the list of skills that each
    //party member can use during the encounter

    //Lists
    public List<EncounterObj> partyList; //the list of party members to use as reference 
    public List<Skills> phillSkills; //Phil's skill list

    //EncounterObj
    public EncounterObj phill;

    //static reference
    public static SkillListController instance;

	// Use this for initialization
	void Start () {
        instance = this;
        //this is a testing function: will try to make better later
        partyList = GetComponent<CreateBattleInstance>().partyList;
        phill = GrabObj("Phil");
        phillSkills = new List<Skills>();
        phillSkills.Add(new Skills("Reckless Abandon", phill.str, 5, phill.anim, targeting.enemy));
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public EncounterObj GrabObj(string name) //TEMP FUNCTION. WIP
    {
        for(int i = 0; i < 2; i++)
        {
            if(partyList[i].name == name)
            {
                return partyList[i];
            }
        }
        return null;
    }
    
}
