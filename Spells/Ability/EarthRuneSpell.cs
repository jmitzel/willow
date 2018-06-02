using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRuneSpell : Ability
{

    private const string abName = "Earth Rune Spell";
    private const string abDescription = "heals you";
    // GameObject abilityPrefab;
    //private const Sprite icon = Resources.Load()
    private const float baseEffectDamage = 5f;

    public EarthRuneSpell()
        : base(new BasicObjectInformation(abName, abDescription))
    {
        UnityEngine.Debug.Log("added behaviors to list");
        //  AbilityBehaviors.Add(new Ranged(10f, 20f));
        AbilityBehaviors.Add(new AreaOfEffect(20f, 5f, baseEffectDamage)); //radius size, how long, and damage
    }
}