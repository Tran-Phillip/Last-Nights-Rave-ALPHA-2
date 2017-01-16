using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSelector : MonoBehaviour {
	//Functions pertaining to creating the selector, creating multiple selectors, and removing the selector

	//Prefabs
	public GameObject selectorPrefab;
   

	//GameObjects
	public GameObject selector;

	//Lists
	public List<GameObject> selectors; //whenever a selector is instantiated, add it to the list for easy deletion

	//static instance
	public static CreateSelector instance;

	void Start()
	{
		instance = this;
		selectors = new List<GameObject>();
		
		
	}
	void Update()
	{
		if(selectors.Count == 0) //FIXME: Add != inBattle
		{
			InstantiateSelector();
		}
	}

	public void InstantiateSelector()
	{
		/*Instantiates and pools a selector at 
		pos 0, 0 ,0. This function runs at the begining 
		of every encounter */
		
		Vector3 origin = new Vector3(0,0,0);		
		selector = Instantiate(selectorPrefab, transform.position, Quaternion.identity) as GameObject;
		selector.SetActive(false);
		selectors.Add(selector);
		selector.transform.position = origin;

	}

	public void MoveSelector(Vector3 pos)
	{
        /*@pos -> Vector3 pos of where you want the selector to move.
		This function moves and activates the selector at another position*/
        pos.y += 1;
		selector.transform.position = pos;
		selector.SetActive(true);

	}

	public void DestroySelector()
	{ 
		//Destroys all selectors on the screen.
		
	
		for(int i = 0; i < selectors.Count; i++)
		{
			Destroy(selectors[i]);

		}
		selectors.Clear();
	}
	
}

