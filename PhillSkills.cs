using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhillSkills : MonoBehaviour {
    //REWRITE THIS
    public  List<Skills> phillSkills;
    public EncounterObj phill;

    




    public static PhillSkills instance;

	// Use this for initialization
	void Start () {
        instance = this;
        phillSkills = SkillListController.instance.phillSkills;
        phill = SkillListController.instance.phill;
	
	}
	
	// Update is called once per frame
	void Update () {    
        if(SkillButton.instance.skillInUse == true)
        {
            if(Input.GetButtonDown("Cancel"))
            {

            }
        }
	
	}
    public void RecklessAbandon()
    {
        SkillButton.instance.skillInUse = true;
        
        for (int i = 0; i < CreateBattleInstance.instance.enemyList.Count; i++)
        {
            CreateSelector.instance.InstantiateSelector();
            CreateSelector.instance.MoveSelector(CreateBattleInstance.instance.enemyList[i].obj.transform.position);
            
            

        }
        StartCoroutine(WaitForInput());

    }
    IEnumerator WaitForInput()
    {
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        
    }
    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
        print("Pew pew pew");

    }


}
