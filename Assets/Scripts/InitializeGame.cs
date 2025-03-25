using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopList
{
    public Item theItem;
    public int amount;
}
public class InitializeGame : MonoBehaviour
{
    public List<ShopList> shopList;
    public List<ShopList> inventoryList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < shopList.Count; ++i)
        {
            GameManager.Instance.shopInventory.AddToInventory(shopList[i].theItem, shopList[i].amount);
        }
        for (int i = 0; i < inventoryList.Count; ++i)
        {
            GameManager.Instance.myInventory.AddToInventory(inventoryList[i].theItem, inventoryList[i].amount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
