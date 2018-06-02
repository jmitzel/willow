using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirRuneInventoryUI : MonoBehaviour
{

    //reference to itemslot
    public Transform itemsParent;
    public GameObject airinventoryUI;

    AirRuneInventory AirInventory;

    AirRuneInventorySlot[] slots;

    // Use this for initialization
    void Start()
    {
        AirInventory = AirRuneInventory.instance;
        AirInventory.onItemChangedCallback1 += UpdateAirUI;
        Debug.Log("air start works");
        slots = itemsParent.GetComponentsInChildren<AirRuneInventorySlot>();
    }


    void UpdateAirUI()
    {
        Debug.Log("update ui air");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < AirInventory.items.Count)
            {
                slots[i].AddItem(AirInventory.items[i]);
            }
        }

    }
}
