using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {

    private BasicObjectInformation objectInfo;
    private List<AbilityBehaviors> behaviors;
  //  private bool requiresTarget;  //requires target
 //   private bool canCastOnSelf; // spell to cast onself
    private float cooldown; // secs
    private GameObject abilityPrefab; //needs to be assigned when we create the ability //the ability prefab
    private float castTime; //secs
    private float cost; // how much it takes to cast
    private AbilityType type;

    public enum AbilityType
    {
        Spell,
        Melee
    }


    public Ability(BasicObjectInformation aBasicInfo)
    {
        objectInfo = aBasicInfo;
        behaviors = new List<global::AbilityBehaviors>();
        cooldown = 4f;
       // requiresTarget = false;
       // canCastOnSelf = false;

    }


    public Ability(BasicObjectInformation aBasicInfo, List<AbilityBehaviors> abehaviors)
    {
        objectInfo = aBasicInfo;
        behaviors = new List<AbilityBehaviors>();
        behaviors = abehaviors;
        cooldown = 4f;
       // requiresTarget = false;
       // canCastOnSelf = false;
        
    }

    public Ability(BasicObjectInformation aBasicInfo, List<AbilityBehaviors> abehaviors, bool arequireTarget, float acooldown, GameObject abilityPb)
    {
        objectInfo = aBasicInfo;
        behaviors = abehaviors;
        cooldown = acooldown;
     //   requiresTarget = arequireTarget;
      //  canCastOnSelf = false;
        abilityPrefab = abilityPb;
        
    }

    public BasicObjectInformation AbilityInfo
    {
        get { return objectInfo; }
    }

    public GameObject AbilityPrefab
    {
        set { abilityPrefab = value; }
    }

    


    public float AbilityCooldown
    {
        get { return cooldown; }
    }

    public List<AbilityBehaviors> AbilityBehaviors
    {
        get { return behaviors; }
    }

    //This is the method that will be called anytime we use an ability
    public virtual void UseAbility(GameObject player)
    {
        UnityEngine.Debug.Log(AbilityBehaviors);
        foreach (AbilityBehaviors b in AbilityBehaviors)
        {
            if (b.AbilityBehaviorStartTime == global::AbilityBehaviors.BehaviorStartTimes.Beginning)
            {
                b.PerformBehavior(player, abilityPrefab);
                UnityEngine.Debug.Log("Performing:" + abilityPrefab);
            }
        }
    }



}
