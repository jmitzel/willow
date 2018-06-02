using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }

    }

    public void Heal(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(RecoverHealth(targetStats, attackDelay));

          //  if (OnAttack != null)
            //    OnAttack();

            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }

    IEnumerator RecoverHealth(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.Heal(myStats.heal.GetValue());
    }



}