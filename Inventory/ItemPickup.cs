using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    public Item item;
    public Button spellButton;
    

    public override void Interact()
    {
        base.Interact();
        Debug.Log("interacting with" + item.name);
        if (item.name == "Water Rune")
        {
            PickUpWaterRune();
            spellButton.gameObject.SetActive(true);

        }
        else if (item.name == "Fire Rune")
        {
            PickUpFireRune();
        }
        else if (item.name == "Earth Rune")
        {
            PickUpEarthRune();
            spellButton.gameObject.SetActive(true);
        }
        else if (item.name == "Air Rune")
        {
            PickUpAirRune();
        }
        else
        {
            PickUp();
        }
        
    }

    void PickUp()
    {
        Debug.Log("Picking  up" + item.name);
            bool wasPickedup = Inventory.instance.Add(item);
            if (wasPickedup)
            {
                Destroy(gameObject);
            }
        
    }
    void PickUpWaterRune()
    {
        Debug.Log("Picking up Water rune");

        bool waterwasPickedup = WaterRuneInventory.instance.Add(item);
        Debug.Log("Picking up water rune bool worked");
        if (waterwasPickedup)
          {
            Destroy(gameObject);
          }
    }

    void PickUpEarthRune()
    {
        Debug.Log("Picking up Earth rune");
        bool earthwasPickedup = EarthRuneInventory.instance.Add(item);
        Debug.Log("Picking up Earth rune bool worked");
        if (earthwasPickedup)
        {
            Destroy(gameObject);
        }
    }
    void PickUpAirRune()
    {
        Debug.Log("Picking up air rune");
        bool airwasPickedup = AirRuneInventory.instance.Add(item);
        Debug.Log("Picking up Earth rune bool worked");
        if (airwasPickedup)
        {
            Destroy(gameObject);
        }
    }

    void PickUpFireRune()
    {
        Debug.Log("Picking up fire rune");
        bool firewasPickedup = FireRuneInventory.instance.Add(item);
        Debug.Log("Picking up fire rune bool worked");
        if (firewasPickedup)
        {
            Destroy(gameObject);
        }
    }

}
    