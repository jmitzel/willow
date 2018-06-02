using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class AbilityUse : PlayerController {

    Animator animator;
    public GameObject waterAttackPrefab;
    public GameObject healingSpellPrefab;
    private EarthRuneSpell earthRuneSpell;
    private WaterRuneSpell waterRuneSpell;
    private Stopwatch abilityCooldownTimer;
    private Stopwatch earthCooldownTimer;
    private Button button;
    private Button earthRune;
    private Image fillImage;
    PlayerManager playerManager;
    CharacterStats myStats;


  


    public Image FillImage
    {
        get
        {
            return fillImage;
        }

        set
        {
            fillImage = value;
        }
    }

    public void OnAbilityUse(GameObject btn)
    {
        //if the ability is not on cd , use it
        FillImage = btn.transform.GetChild(0).gameObject.GetComponent<Image>();
        UnityEngine.Debug.Log(btn.transform.GetChild(0).gameObject.name);
        button = btn.GetComponent<Button>();
        button.interactable = false;
        FillImage.fillAmount = 1;
        abilityCooldownTimer = new Stopwatch();
        abilityCooldownTimer.Start();
        if (focus != null)
        {
            // if (focus.gameObject.tag == "Enemy")
            //  {
            animator = GetComponent<Animator>();
            animator.SetInteger("WillowState", 1);
            CharacterStats targetStats = focus.GetComponent<CharacterStats>();
            playerManager = PlayerManager.instance;
            CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
            if (playerCombat != null && targetStats != null)
            {
                playerCombat.Attack(targetStats);
            }

   //     } 
        


            GameObject go = Instantiate<GameObject>(waterAttackPrefab);
       
        
            go.transform.position = focus.transform.position; //target position
            waterRuneSpell = new WaterRuneSpell();
            waterRuneSpell.AbilityPrefab = go;
            waterRuneSpell.UseAbility(gameObject);

            




            StartCoroutine(SpinImage());
        }
        else
        {
            UnityEngine.Debug.Log("need to target something");
            button.interactable = true;
        }
   

    }

    public void HealingSpell(GameObject ebtn)
    {
        //if the ability is not on cd , use it
        FillImage = ebtn.transform.GetChild(0).gameObject.GetComponent<Image>();
        UnityEngine.Debug.Log(ebtn.transform.GetChild(0).gameObject.name);
        earthRune = ebtn.GetComponent<Button>();
        earthRune.interactable = false;
        FillImage.fillAmount = 1;
        earthCooldownTimer = new Stopwatch();
        earthCooldownTimer.Start();

        animator = GetComponent<Animator>();
        animator.SetInteger("WillowState", 1);


        CharacterStats myStats = GetComponent<CharacterStats>();
        playerManager = PlayerManager.instance;
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
          {
                playerCombat.Heal(myStats);
          }
       


        GameObject go = Instantiate<GameObject>(healingSpellPrefab);
      
        go.transform.position = this.transform.position;

        earthRuneSpell = new EarthRuneSpell();
        earthRuneSpell.AbilityPrefab = go;
        earthRuneSpell.UseAbility(gameObject);

        StartCoroutine(SpinEarthImage());

    }

    private IEnumerator SpinImage()
    {
       // UnityEngine.Debug.Log(waterRuneSpell.AbilityCooldown);
        while (abilityCooldownTimer.IsRunning && abilityCooldownTimer.Elapsed.TotalSeconds < waterRuneSpell.AbilityCooldown)
        {
           // UnityEngine.Debug.Log(FillImage.fillAmount);
            FillImage.fillAmount = ((float)abilityCooldownTimer.Elapsed.TotalSeconds / waterRuneSpell.AbilityCooldown);
            yield return null;
        }
        FillImage.fillAmount = 0;
        button.interactable = true;
        animator = GetComponent<Animator>();
        animator.SetInteger("WillowState", 0);
        
        abilityCooldownTimer.Stop();
        abilityCooldownTimer.Reset();

        yield return null;
    }

    private IEnumerator SpinEarthImage()
    {
        // UnityEngine.Debug.Log(waterRuneSpell.AbilityCooldown);
        while (earthCooldownTimer.IsRunning && earthCooldownTimer.Elapsed.TotalSeconds < earthRuneSpell.AbilityCooldown)
        {
            // UnityEngine.Debug.Log(FillImage.fillAmount);
            FillImage.fillAmount = ((float)earthCooldownTimer.Elapsed.TotalSeconds / earthRuneSpell.AbilityCooldown);
            yield return null;
        }
        FillImage.fillAmount = 0;
        animator = GetComponent<Animator>();
        animator.SetInteger("WillowState", 0);

        earthRune.interactable = true;
        earthCooldownTimer.Stop();
        earthCooldownTimer.Reset();

        yield return null;
    }

}
