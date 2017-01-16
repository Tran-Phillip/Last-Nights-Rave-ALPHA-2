using UnityEngine;
using System.Collections;
using System;

public class EncounterObj : IComparable<EncounterObj>
{
		/*class that represents the enemy/party member/party member encounter
		@ID -> database ID of the enemy/party member/party member
		@obj -> GameObject assosiated with enemy/party member/party member
		@name -> name of enemy/party member/party member 
		@hp -> number of hit-points, when zero the enemy/party member is "killed" and GameObject is destroyed
		@str -> how strong the enemy/party member attack is. 
		@dex -> how strong the enemy/party member ranged attack is.
		@intel -> how strong the enemy/party member magical attacks are and the maximum amount of spells an enemy/party member can cast.
		@agi -> how fast the enemy/party member is and their place in the turn order. Also controls dodge rate. 
		@luk -> controls the liklihood of a critical hit and dodge rate. 
        @anim -> the animation controller or the target

		*/
		public int ID;
		public GameObject obj; 
		public string name; 
		public int hp; 
		public int str;
		public int dex;
		public int intel;
		public int agi;
		public int luk;
        public Animator anim;
      

	public EncounterObj(int newID ,GameObject newObj, string newName, int newHp, int newStr, int newDex, int newIntel, int newAgi, int newLuk, Animator newAnim)
	{   /*Call this function when you want to add a new enemy/party member 
		using the same parameters as above*/
		ID = newID;
		obj = newObj;
		name = newName;
		hp = newHp;
        str = newStr;
		dex = newDex;
		intel = newIntel;
		agi = newAgi;
		luk = newLuk;
        anim = newAnim;
	}

	public int CompareTo(EncounterObj obj) 
	{
		if(obj == null)
		{
			return 1;
		}
		else
		{
			return obj.agi - agi;
		}
	}
}