using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterRuneInventoryUI : MonoBehaviour
{

    //reference to itemslot
    public Transform itemsParent;
    public GameObject waterinventoryUI;

    WaterRuneInventory waterInventory;

    WaterRuneInventorySlot[] slots;

    // Use this for initialization
    void Start()
    {
        waterInventory = WaterRuneInventory.instance;
        waterInventory.onItemChangedCallback1 += UpdatewaterUI;
        Debug.Log("water start works");
        slots = itemsParent.GetComponentsInChildren<WaterRuneInventorySlot>();
    }


    void UpdatewaterUI()
    {
        Debug.Log("update ui water");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < waterInventory.items.Count)
            {
                slots[i].AddItem(waterInventory.items[i]);
            }
        }

    }
}
