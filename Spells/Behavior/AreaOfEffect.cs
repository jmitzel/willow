using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics; //used for stopwatch

public class AreaOfEffect : AbilityBehaviors {

   

    private const string abName = "Ranged";
    private const string abDescription = "Area of damage";
    // private const Sprite icon = Resources.Load()
    private const BehaviorStartTimes startTime = BehaviorStartTimes.Beginning; //when dmg happens //on impact

    private float areaRadius; //radius of spehere collider
    private float effectDuration; //how long the effect lasts
    private Stopwatch durationTimer = new Stopwatch();
    private float baseEffectDamage;
    private bool isOccupied;
    private float damageTickDuration; // 

   

    public AreaOfEffect(float ar, float ed, float bd) 
        : base(new BasicObjectInformation(abName, abDescription), startTime)
    {
        areaRadius = ar;
        effectDuration = ed;
        baseEffectDamage = bd;
        isOccupied = false;

    }

    public override void PerformBehavior(GameObject playerObject, GameObject abilityPrefab)
    {
        Job.make(AOE(abilityPrefab));
        UnityEngine.Debug.Log("started coroutine");
        //   SphereCollider sc;
        //  if (gameObject.GetComponent<SphereCollider>() == null)
        //  {
        //    sc = gameObject.AddComponent<SphereCollider>();
        // }
        // else
        // {
        //    sc = gameObject.GetComponent<SphereCollider>();
        // }
        //sc.radius = areaRadius; //set radius
        //sc.isTrigger = true; //turn on sphere collider trigger
        //StartCoroutine(AOE());

    }

    private IEnumerator AOE(GameObject abilityPrefab)
    {
        durationTimer.Start(); //turns on timer

        if (durationTimer.Elapsed.TotalSeconds < effectDuration)
        {
           
                UnityEngine.Debug.Log("Did Damage");
               
                //do damage
            
            yield return new WaitForSeconds(effectDuration);
        }
        
            UnityEngine.Debug.Log("finished with water rune spell");
            GameObject.Destroy(abilityPrefab);
            durationTimer.Stop(); //stop timer
            durationTimer.Reset();
            yield return null;
        
       
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied)
        {
            //do damage here
        }
        else
        {
            isOccupied = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }
}
