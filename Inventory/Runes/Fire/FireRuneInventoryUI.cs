using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRuneInventoryUI : MonoBehaviour
{

    //reference to itemslot
    public Transform itemsParent;
    public GameObject fireinventoryUI;

    FireRuneInventory fireInventory;

    FireRuneInventorySlot[] slots;

    // Use this for initialization
    void Start()
    {
        fireInventory = FireRuneInventory.instance;
        fireInventory.onItemChangedCallback1 += UpdatefireUI;
        Debug.Log("water start works");
        slots = itemsParent.GetComponentsInChildren<FireRuneInventorySlot>();
    }


    void UpdatefireUI()
    {
        Debug.Log("update ui water");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < fireInventory.items.Count)
            {
                slots[i].AddItem(fireInventory.items[i]);
            }
        }

    }
}
