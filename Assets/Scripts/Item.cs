using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public bool questItem = false;
    public string itemName;
    public string itemDesc;
    public string itemStatBonus;
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
}
