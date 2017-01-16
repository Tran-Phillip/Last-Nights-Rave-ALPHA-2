using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyInfoScript : MonoBehaviour {
    //Functions related to the Info Display are located here

    //Prefabs
    public GameObject enemyInfoPrefab;

    //GameObjects
    public GameObject enemyInfoBox;

    //Text Panal
    public Image textPanal;

    //Text
    public Text enemyName;
    public Text info;

    //Canvas
    public Canvas mainBattleCanvas;
   

    //static reference
    public static EnemyInfoScript instance;

    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CreateEnemyInfoBox(EncounterObj target)
    {
        //@target -> the current hover target
        //This function creates an information box over an enemy
        //displaying health and other stats

        //Instantiate the enemy info box as a child of the main canvas
        enemyInfoBox = Instantiate(enemyInfoPrefab, transform.position, Quaternion.identity) as GameObject;
        enemyInfoBox.transform.SetParent(mainBattleCanvas.transform, false);

        //Re-add the name and info parameters
        enemyName = GameObject.Find("Name").GetComponent<UnityEngine.UI.Text>();
        info = GameObject.Find("Info").GetComponent<UnityEngine.UI.Text>();
        

        MoveInfoBox(target);

    }

    public void MoveInfoBox(EncounterObj target)
    {
       // @target->the current hover target
       //This function moves the target information box
       
        //Get the WorldToScreenPoint pos because UI elements exist in the world space. We want the position of the textbox to be slightly 
        //above the enemy
        Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(target.obj.transform.position.x, target.obj.transform.position.y + 1.6f, target.obj.transform.position.z));

        //move the textbox
        enemyInfoBox.transform.position = pos;

        //Display the target's infomation
        DisplayInfo(target);
    }
    
    public void DisplayInfo(EncounterObj target)
    {
        //@target -> target being hovered over
        //Displays the relevent stats of target being hovered over

        enemyName.text = target.name;
        info.text = "HP : " + target.hp + "\n" + "Atk : " + target.str;
    }
    public void DestroyInfoBox()
    {
        Destroy(enemyInfoBox);
    }
   

}
