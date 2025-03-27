using NUnit.Framework;
using UnityEngine;

[System.Flags]
public enum Character
{
    Randi = 1 << 0,
    Purim = 1 << 1,
    Popoi = 1 << 2

}
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public bool questItem = false;
    public string itemName;
    public string itemDesc;
    public string itemStatBonus;
    public Character characterList;
    [SerializeField]
    Sprite itemImage;
    [SerializeField]
    private int quantity = 0;
    public int cost = 0;
    public int sellPrice = 0;
    public void AddQuantity(int amount)
    {
        quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        quantity -= amount;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public Texture2D GetItemImage()
    {
        return itemImage.texture;
    }
    public void SetQuantity(int amount)
    {
        quantity = amount;
    }
    public bool CanBeEquippedBy(Character theCharacter)
    {
        return (characterList & theCharacter) != 0;
    }
}
