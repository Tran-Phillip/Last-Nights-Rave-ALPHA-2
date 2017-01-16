using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TestingScript : MonoBehaviour {

    public Button skillButtonPrefab;
    public Button skillButton;
    public Canvas mainBattleCanvas;
    public GameObject skillSlot1;
    public GameObject skillSlot2;
    public GameObject[] skillSlots;
    public List<Button> buttonList;
    public Text text1;
    public Text text2;

	// Use this for initialization
	void Start () {
        buttonList = new List<Button>();
        skillSlots = new GameObject[] { skillSlot1, skillSlot2 };
        makeButton(skillButtonPrefab, skillButton);
        makeButton(skillButtonPrefab, skillButton);

        AssignToSkillSlot(skillSlots, buttonList[0]);
       

        text1 = buttonList[0].GetComponentInChildren<Text>();
        text1.text = "Reckless Abandon!";


    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AssignToSkillSlot(GameObject[] skillSlots, Button skillButton)
    {
        for(int i = 0; i < skillSlots.Length; i++)
        {
            if(skillSlots[i].transform.childCount == 0)
            {
                //Vector3 pos = Camera.main.WorldToScreenPoint(skillSlots[i].transform.position);
                skillButton.transform.SetParent(skillSlots[i].transform);
                skillButton.transform.position = skillSlots[i].transform.position;
                return;
            }
        }

    }
    public void makeButton(Button buttonPrefab, Button skillButton)
    {
        skillButton = Instantiate(skillButtonPrefab, transform.position, Quaternion.identity) as Button;
        skillButton.transform.SetParent(mainBattleCanvas.transform);
        skillButton.onClick.AddListener(() => PhillSkills.instance.RecklessAbandon());
        buttonList.Add(skillButton);
    }
}
