using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour {

    //bools
    public bool skillInUse;

    //static reference
    public static SkillButton instance;

	// Use this for initialization
	void Start () {
        instance = this;
        skillInUse = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SkillButtonPressed()
    {
        skillInUse = true;
        //bring up the skill menu
    }
}
