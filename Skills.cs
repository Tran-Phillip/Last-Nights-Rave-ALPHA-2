using UnityEngine;
using System.Collections;

public enum targeting { self, partyMember, enemy };
public class Skills
{
    public string name;
    public int damage;
    public int cost;
    public Animator anim;
    public targeting target;

    public Skills(string newName, int newDamage, int newCost, Animator newAnim, targeting howTarget)
    {
        name = newName;
        damage = newDamage;
        cost = newCost;
        anim = newAnim;
        target = howTarget;
    }
	
}
