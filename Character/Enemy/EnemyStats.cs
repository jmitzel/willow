using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : CharacterStats {

    Animator animator;


    private void Start()
    {
        health.MaxValue = 15;
        health.CurrentValue = health.MaxValue;
        animator = GetComponent<Animator>();
    }
    public override void Die()
    {
        base.Die();

        animator.SetTrigger("die");

        StartCoroutine(Death(5));
    }

    IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }

    //good place to add loot

}
