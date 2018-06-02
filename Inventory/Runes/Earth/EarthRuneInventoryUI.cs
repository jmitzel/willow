using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthRuneInventoryUI : MonoBehaviour
{

    //reference to itemslot
    public Transform itemsParent;
    public GameObject earthnventoryUI;

    EarthRuneInventory earthInventory;

    EarthRuneInventorySlot[] slots;

    // Use this for initialization
    void Start()
    {
        earthInventory = EarthRuneInventory.instance;
        earthInventory.onItemChangedCallback1 += UpdateEarthUI;
        Debug.Log("water start works");
        slots = itemsParent.GetComponentsInChildren<EarthRuneInventorySlot>();
    }


    void UpdateEarthUI()
    {
        Debug.Log("update ui earth");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < earthInventory.items.Count)
            {
                slots[i].AddItem(earthInventory.items[i]);
            }
        }

    }
}
