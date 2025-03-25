using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> items = new List<Item>();

    public void AddToInventory(Item item,int amount = 1)
    {
        Item theItem = items.Find(theItem => theItem != null && theItem.itemName == item.itemName);
        if (theItem)
        {
            theItem.AddQuantity(amount);
        }
        else
        {
            int emptyIndex = items.FindIndex(theItem => theItem == null);
            if (emptyIndex != -1)
            {
                Item newItem = GameObject.Instantiate(item);
                newItem.SetQuantity(0);
                newItem.AddQuantity(amount);
                items[emptyIndex] = newItem;
            }
            else
            {
                Item newItem = GameObject.Instantiate(item);
                newItem.SetQuantity(0);
                newItem.AddQuantity(amount);
                items.Add(newItem);
            }
        }
    }

    public void RemoveFromInventory(Item item, int amount = 1)
    {
        Item theItem = items.Find(theItem => theItem != null && theItem.itemName == item.itemName);
        if (theItem)
        {
            int itemIndex = items.FindIndex(theItem => theItem != null && theItem.itemName == item.itemName);
            theItem.RemoveQuantity(amount);
            if (theItem.GetQuantity() <= 0)
            {
                items[itemIndex] = null;
            }
        }
    }

    public List<Item> GetItemList()
    {
        return items;
    }
}
