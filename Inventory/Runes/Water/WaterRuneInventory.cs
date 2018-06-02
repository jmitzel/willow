using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRuneInventory : MonoBehaviour
{
    #region Singleton
    public static WaterRuneInventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged1();
    public OnItemChanged1 onItemChangedCallback1;

    public int space = 4;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        Debug.Log("check here");
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
            Debug.Log("Rune added");
            items.Add(item);
            if (onItemChangedCallback1 != null)
            {
                onItemChangedCallback1.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        {
            items.Remove(item);
            if (onItemChangedCallback1 != null)
            {
                onItemChangedCallback1.Invoke();
            }
        }
    }



}
