using UnityEngine;

public class CharacterStats : MonoBehaviour {

    // public int maxHealth = 100;
    // public int CurrentHealth { get; private set;}

    public Stat health;
    public Stat damage;
    public Stat armor;
    public GameObject healthBar;
    public Stat heal;

    private void Awake()
    {
        //CurrentHealth = maxHealth;
        health.MaxValue = 100;
        health.CurrentValue = health.MaxValue;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        // What are armor does
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // CurrentHealth -= damage;
        health.CurrentValue -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");

        //if (CurrentHealth <= 0)
        if (health.CurrentValue <= 0)
        {
            Die();
            healthBar.SetActive(false);
        }
    }

    public void Heal(int heal)
    {
        // What are armor does
      //  damage -= armor.GetValue();
       // damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // CurrentHealth -= damage;
        health.CurrentValue += heal;
        Debug.Log(transform.name + " recovered" + heal + "heal.");

        ////if (CurrentHealth <= 0)
       // if (health.CurrentValue <= 0)
       // {
       //     Die();
       //     healthBar.SetActive(false);
      //  }
    }
    //This will be overidden
    public virtual void Die ()
    {
        Debug.Log(transform.name + "dies");
    }
}
