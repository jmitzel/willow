using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : AbilityBehaviors {

    private const string rName = "Ranged";
    private const string rDescription = "A ranged attack";
    // private const Sprite icon = Resources.Load()
    private const BehaviorStartTimes startTime = BehaviorStartTimes.Beginning;

    private float minDistance;
    private float maxDistance;
    private float lifeDistance;
    
	public Ranged(float minDist, float maxDist) 
        : base(new BasicObjectInformation(rName, rDescription), startTime)
    {
        minDistance = minDist;
        maxDistance = maxDist;

    }

    //Using a job manager created by Prime31 to handle coroutines
    public override void PerformBehavior(GameObject playerObject, GameObject abilityPrefab)
    {
        lifeDistance = maxDistance;
        Debug.Log("Distance: " + lifeDistance); //added
        Job.make(CheckDistance(playerObject.transform.position, abilityPrefab), true);
        //StartCoroutine(CheckDistance(startPosition));

    }

    private IEnumerator CheckDistance(Vector3 startPosition, GameObject abilityPrefab)
    {
        float tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);
        while (tempDistance < lifeDistance)
        {
            if (tempDistance >= lifeDistance)
            {
                tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);
            }
            //  this.gameObject.SetActive(false);  //object pooling code or destory
            GameObject.Destroy(abilityPrefab);
            yield return null;
        }
    }

    public float MinDistance
    {
        get { return minDistance; }
    }

    public float MaxDistance
    {
        get { return maxDistance; }
    }
}
