using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRuneSpell : Ability
{

    private const string abName = "Water Rune Spell";
    private const string abDescription = "Surge the target with elemental water";
    // GameObject abilityPrefab;
    //private const Sprite icon = Resources.Load()
    private const float baseEffectDamage = 5f;

    public WaterRuneSpell()
        : base(new BasicObjectInformation(abName, abDescription))
    {
        UnityEngine.Debug.Log("added behaviors to list");
        //  AbilityBehaviors.Add(new Ranged(10f, 20f));
        AbilityBehaviors.Add(new AreaOfEffect(20f, 3f, baseEffectDamage)); //radius size, how long, and damage
    }
}