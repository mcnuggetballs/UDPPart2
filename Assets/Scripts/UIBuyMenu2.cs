using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
[System.Serializable]
public class Slot
{
    public bool inventorySlot = false;
    private bool isSelected = false;
    public int slotIndex = -1;
    public Button itemButton = null;
    public VisualElement itemImage = null;
    public Label quantityText = null;

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }

        set
        {
            isSelected = value;
        }
    }
}
public class UIBuyMenu2 : Page
{
    public Dictionary<int, Slot> slotList = new Dictionary<int, Slot>();
    public List<Slot> shopSlots = new List<Slot>();
    public List<Slot> invSlots = new List<Slot>();


    public VisualElement ItemImage = null;
    public Label ItemName = null;
    public Label ItemDesc = null;
    public Label ItemQuantity = null;
    public Button QuantityRButton = null;
    public Button QuantityLButton = null;
    public Button BuyOrSellButton = null;
    public Label TotalCost = null;
    public Label MyMoney = null;
    public Label ItemStatDesc = null;
    public VisualElement Randi = null;
    public VisualElement Purim = null;
    public VisualElement Popoi = null;
    public bool isConfirming = false;
    public VisualElement ConfirmationMenu = null;
    public Label ConfirmText = null;
    public Button CancelConfirmButton = null;
    public Button ConfirmButton = null;
    public bool isNotif = false;
    public VisualElement NotifMenu = null;
    public Label NotifText = null;
    public Button NotifCloseButton = null;


    public int selectedIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _root = doc.rootVisualElement;
        int index = 1;
        bool finished = false;
        while (finished == false)
        {
            Slot newSlot = new Slot();
            newSlot.inventorySlot = false;
            newSlot.itemButton = _root.Q<Button>("Slot" + index.ToString());
            newSlot.itemImage = _root.Q<VisualElement>("Slot" + index.ToString() + "Item");
            newSlot.quantityText = _root.Q<Label>("Slot" + index.ToString() + "Quantity");
            if (newSlot.itemButton == null)
            {
                finished = true;
                break;
            }
            newSlot.slotIndex = index-1;
            shopSlots.Add(newSlot);
            slotList.Add(slotList.Count,newSlot);
            ++index;
        }
        finished = false;
        index = 1;

        while (finished == false)
        {
            Slot newSlot = new Slot();
            newSlot.inventorySlot = true;
            newSlot.itemButton = _root.Q<Button>("InvSlot" + index.ToString());
            newSlot.itemImage = _root.Q<VisualElement>("InvSlot" + index.ToString() + "Item");
            newSlot.quantityText = _root.Q<Label>("InvSlot" + index.ToString() + "Quantity");
            if (newSlot.itemButton == null)
            {
                finished = true;
                break;
            }
            newSlot.slotIndex = index - 1;
            slotList.Add(slotList.Count, newSlot);
            invSlots.Add(newSlot);
            ++index;
        }

        ItemImage = _root.Q<VisualElement>("ItemImage");
        ItemName = _root.Q<Label>("ItemName");
        ItemDesc = _root.Q<Label>("ItemDesc");
        ItemQuantity = _root.Q<Label>("ItemQuantity");
        QuantityRButton = _root.Q<Button>("QuantityRButton");
        QuantityLButton = _root.Q<Button>("QuantityLButton");
        BuyOrSellButton = _root.Q<Button>("BuyOrSellButton");
        TotalCost = _root.Q<Label>("TotalCost");
        MyMoney = _root.Q<Label>("MyMoney");
        ItemStatDesc = _root.Q<Label>("ItemStatDesc");
        Randi = _root.Q<VisualElement>("Randi");
        Purim = _root.Q<VisualElement>("Purim");
        Popoi = _root.Q<VisualElement>("Popoi");
        ConfirmationMenu = _root.Q<VisualElement>("ConfirmationMenu");
        ConfirmText = _root.Q<Label>("ConfirmText");
        CancelConfirmButton = _root.Q<Button>("CancelConfirmButton");
        ConfirmButton = _root.Q<Button>("ConfirmButton");
        NotifMenu = _root.Q<VisualElement>("NotifMenu");
        NotifText = _root.Q<Label>("NotifText");
        NotifCloseButton = _root.Q<Button>("NotifCloseButton");

        HighlightButton(slotList[selectedIndex].itemButton);

    }
    void NextIndex()
    {
        if (selectedIndex + 1 >= slotList.Count)
        {
            return;
        }
        DehighlightButton(slotList[selectedIndex].itemButton);
        ++selectedIndex;
        HighlightButton(slotList[selectedIndex].itemButton);

        DescPanelUpdate();
    }
    void BackIndex()
    {
        if (selectedIndex - 1 < 0)
        {
            return;
        }
        DehighlightButton(slotList[selectedIndex].itemButton);
        --selectedIndex;
        HighlightButton(slotList[selectedIndex].itemButton);

        DescPanelUpdate();
    }
    void DownIndex()
    {
        if (selectedIndex + 7 >= slotList.Count)
        {
            return;
        }
        DehighlightButton(slotList[selectedIndex].itemButton);
        selectedIndex += 7;
        HighlightButton(slotList[selectedIndex].itemButton);

        DescPanelUpdate();
    }
    void UpIndex()
    {
        if (selectedIndex - 7 < 0)
        {
            return;
        }
        DehighlightButton(slotList[selectedIndex].itemButton);
        selectedIndex -= 7;
        HighlightButton(slotList[selectedIndex].itemButton);

        DescPanelUpdate();
    }
    void HighlightButton(Button theButton)
    {
        theButton.style.borderBottomColor = Color.yellow;
        theButton.style.borderTopColor = Color.yellow;
        theButton.style.borderLeftColor = Color.yellow;
        theButton.style.borderRightColor = Color.yellow;
    }

    void DehighlightButton(Button theButton)
    {
        theButton.style.borderBottomColor = Color.white;
        theButton.style.borderTopColor = Color.white;
        theButton.style.borderLeftColor = Color.white;
        theButton.style.borderRightColor = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void ControllerUpdate()
    {
        if (isConfirming == false && isNotif == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                NextIndex();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                BackIndex();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                UpIndex();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                DownIndex();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
                Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
                if (theShopSlot != null)
                {
                    if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                        if (theItem != null)
                        {
                            int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                            if (currentQuantity + 1 <= theItem.GetQuantity())
                            {
                                ++currentQuantity;
                                ItemQuantity.text = currentQuantity.ToString();
                            }
                        }
                    }
                }
                if (theInvSlot != null)
                {
                    if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                        if (theItem != null)
                        {
                            int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                            if (currentQuantity + 1 <= theItem.GetQuantity())
                            {
                                ++currentQuantity;
                                ItemQuantity.text = currentQuantity.ToString();
                            }
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
                Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
                if (theShopSlot != null)
                {
                    if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                        if (theItem != null)
                        {
                            int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                            if (currentQuantity - 1 >= 1)
                            {
                                --currentQuantity;
                                ItemQuantity.text = currentQuantity.ToString();
                            }
                        }
                    }
                }
                if (theInvSlot != null)
                {
                    if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                        if (theItem != null)
                        {
                            int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                            if (currentQuantity - 1 >= 1)
                            {
                                --currentQuantity;
                                ItemQuantity.text = currentQuantity.ToString();
                            }
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isConfirming == false && isNotif == false)
            {
                UIManager.Instance.SetCurrentPage(UIManager.Instance._optionsPage);
            }
            if (isConfirming == true)
            {
                isConfirming = false;
                ConfirmationMenu.style.display = DisplayStyle.None;
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isConfirming == false && isNotif == false)
            {
                Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
                Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
                if (theShopSlot != null)
                {
                    if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                        if (theItem != null)
                        {
                            int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                            int totalCost = currentQuantity * theItem.cost;
                            if (theItem.questItem)
                            {
                                NotifText.text = "Restricted Item!";
                                isNotif = true;
                                NotifMenu.style.display = DisplayStyle.Flex;
                            }
                            else if (GameManager.Instance.myMoney >= totalCost)
                            {
                                ConfirmText.text = "Confirm Purchase?";
                                isConfirming = true;
                                ConfirmationMenu.style.display = DisplayStyle.Flex;
                            }
                            else
                            {
                                NotifText.text = "Insufficient Gold!";
                                isNotif = true;
                                NotifMenu.style.display = DisplayStyle.Flex;
                            }
                        }
                    }
                }
                else if (theInvSlot != null)
                {
                    if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
                    {
                        Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                        if (theItem != null)
                        {
                            if (theItem.questItem)
                            {
                                NotifText.text = "Restricted Item!";
                                isNotif = true;
                                NotifMenu.style.display = DisplayStyle.Flex;
                            }
                            else
                            {
                                ConfirmText.text = "Confirm Sell?";
                                isConfirming = true;
                                ConfirmationMenu.style.display = DisplayStyle.Flex;
                            }
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                if (isConfirming == true)
                {
                    isConfirming = false;
                    Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
                    Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
                    if (theShopSlot != null)
                    {
                        if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
                        {
                            Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                            if (theItem != null)
                            {
                                int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                                int totalCost = currentQuantity * theItem.cost;
                                if (GameManager.Instance.myMoney >= totalCost)
                                {
                                    GameManager.Instance.myMoney -= totalCost;
                                    GameManager.Instance.myInventory.AddToInventory(theItem, currentQuantity);
                                    GameManager.Instance.shopInventory.RemoveFromInventory(theItem, currentQuantity);
                                    DescPanelUpdate();

                                    if (GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex] != null)
                                    {
                                        if (currentQuantity > GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex].GetQuantity())
                                        {
                                            currentQuantity = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex].GetQuantity();
                                            ItemQuantity.text = currentQuantity.ToString();
                                        }
                                    }
                                    else
                                    {
                                        ItemQuantity.text = "0";
                                    }
                                }
                            }
                        }
                    }
                    if (theInvSlot != null)
                    {
                        if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
                        {
                            Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                            if (theItem != null && theItem.questItem == false)
                            {
                                int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                                int totalCost = currentQuantity * theItem.sellPrice;
                                GameManager.Instance.myMoney += totalCost;
                                GameManager.Instance.shopInventory.AddToInventory(theItem, currentQuantity);
                                GameManager.Instance.myInventory.RemoveFromInventory(theItem, currentQuantity);
                                DescPanelUpdate();

                                if (GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex] != null)
                                {
                                    if (currentQuantity > GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex].GetQuantity())
                                    {
                                        currentQuantity = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex].GetQuantity();
                                        ItemQuantity.text = currentQuantity.ToString();
                                    }
                                }
                                else
                                {
                                    ItemQuantity.text = "0";
                                }
                            }
                        }
                    }
                    ConfirmationMenu.style.display = DisplayStyle.None;
                }
                else if (isNotif)
                {
                    NotifMenu.style.display = DisplayStyle.None;
                    isNotif = false;
                }
            }
        }
    }
    void TotalCostUpdate()
    {
        Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
        Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
        if (theShopSlot != null)
        {
            BuyOrSellButton.text = "Buy(A)";
            if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
            {
                Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                if (theItem != null)
                {
                    ItemImage.style.backgroundImage = new StyleBackground(theItem.GetItemImage());
                    ItemName.text = theItem.itemName;
                    ItemDesc.text = theItem.itemDesc;
                    TotalCost.text = (theItem.cost * Convert.ToInt32(ItemQuantity.text)).ToString() + "g";


                    int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                    int totalCost = currentQuantity * theItem.cost;

                    if (GameManager.Instance.myMoney >= totalCost)
                    {
                        BuyOrSellButton.style.backgroundColor = Color.white;
                    }
                    else
                    {
                        BuyOrSellButton.style.backgroundColor = Color.grey;
                    }
                }
                else
                {
                    ItemImage.style.backgroundImage = null;
                    ItemName.text = "No Item";
                    ItemDesc.text = "";
                    TotalCost.text = "0g";
                    BuyOrSellButton.style.backgroundColor = Color.grey;
                }
            }
            else
            {
                BuyOrSellButton.style.backgroundColor = Color.grey;
            }
        }
        else if (theInvSlot != null)
        {
            BuyOrSellButton.text = "Sell(A)";
            if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
            {
                Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                if (theItem != null)
                {
                    ItemImage.style.backgroundImage = new StyleBackground(theItem.GetItemImage());
                    ItemName.text = theItem.itemName;
                    ItemDesc.text = theItem.itemDesc;
                    TotalCost.text = (theItem.sellPrice * Convert.ToInt32(ItemQuantity.text)).ToString() + "g";

                    int currentQuantity = Convert.ToInt32(ItemQuantity.text);
                    int totalCost = currentQuantity * theItem.cost;

                    if (theItem.questItem == false)
                    {
                        BuyOrSellButton.style.backgroundColor = Color.white;
                    }
                    else
                    {
                        BuyOrSellButton.style.backgroundColor = Color.grey;
                    }
                }
                else
                {
                    ItemImage.style.backgroundImage = null;
                    ItemName.text = "No Item";
                    ItemDesc.text = "";
                    TotalCost.text = "0g";
                    BuyOrSellButton.style.backgroundColor = Color.grey;
                }
            }
            else
            {
                BuyOrSellButton.style.backgroundColor = Color.grey;
            }
        }
        else
        {
            BuyOrSellButton.style.backgroundColor = Color.grey;
        }
    }
    void DescPanelUpdate()
    {
        bool hasItem = false;
        Slot theShopSlot = shopSlots.Find(shopSlot => shopSlot == slotList[selectedIndex]);
        Slot theInvSlot = invSlots.Find(invSlot => invSlot == slotList[selectedIndex]);
        if (theShopSlot != null)
        {
            if (GameManager.Instance.shopInventory.GetItemList().Count > theShopSlot.slotIndex)
            {
                Item theItem = GameManager.Instance.shopInventory.GetItemList()[theShopSlot.slotIndex];
                if (theItem != null)
                {
                    ItemImage.style.backgroundImage = new StyleBackground(theItem.GetItemImage());
                    ItemName.text = theItem.itemName;
                    ItemDesc.text = theItem.itemDesc;
                    string[] statArray = theItem.itemStatBonus.Split('_');
                    ItemStatDesc.text = "";
                    foreach (string stat in statArray)
                    {
                        ItemStatDesc.text += stat;
                        ItemStatDesc.text += '\n';
                    }
                    ItemQuantity.text = "1";
                    hasItem = true;
                    if (theItem.CanBeEquippedBy(Character.Randi))
                    {
                        Randi.style.unityBackgroundImageTintColor = new Color(1.0f,1.0f,1.0f,1.0f);
                    }
                    else
                    {
                        Randi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                    if (theItem.CanBeEquippedBy(Character.Purim))
                    {
                        Purim.style.unityBackgroundImageTintColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        Purim.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                    if (theItem.CanBeEquippedBy(Character.Popoi))
                    {
                        Popoi.style.unityBackgroundImageTintColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        Popoi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                }
            }
        }
        else if (theInvSlot != null)
        {
            if (GameManager.Instance.myInventory.GetItemList().Count > theInvSlot.slotIndex)
            {
                Item theItem = GameManager.Instance.myInventory.GetItemList()[theInvSlot.slotIndex];
                if (theItem != null)
                {
                    ItemImage.style.backgroundImage = new StyleBackground(theItem.GetItemImage());
                    ItemName.text = theItem.itemName;
                    ItemDesc.text = theItem.itemDesc;
                    string[] statArray = theItem.itemStatBonus.Split('_');
                    ItemStatDesc.text = "";
                    foreach (string stat in statArray)
                    {
                        ItemStatDesc.text += stat;
                        ItemStatDesc.text += '\n';
                    }
                    ItemQuantity.text = "1";
                    hasItem = true;

                    if (theItem.CanBeEquippedBy(Character.Randi))
                    {
                        Randi.style.unityBackgroundImageTintColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        Randi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                    if (theItem.CanBeEquippedBy(Character.Purim))
                    {
                        Purim.style.unityBackgroundImageTintColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        Purim.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                    if (theItem.CanBeEquippedBy(Character.Popoi))
                    {
                        Popoi.style.unityBackgroundImageTintColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        Popoi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
                    }
                }
            }
        }
        if (hasItem == false)
        {
            ItemImage.style.backgroundImage = null;
            ItemName.text = "";
            ItemDesc.text = "";
            ItemStatDesc.text = "";
            ItemQuantity.text = "1";
            TotalCost.text = "0g";
            Randi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
            Purim.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
            Popoi.style.unityBackgroundImageTintColor = new Color(93.0f / 255.0f, 93.0f / 255.0f, 93.0f / 255.0f, 255.0f / 255.0f);
        }
    }
    void ShopSlotUpdate()
    {
        for (int i = 0; i < shopSlots.Count; ++i)
        {
            if (GameManager.Instance.shopInventory.GetItemList().Count <= i)
                return;
            Slot shopSlot = shopSlots[i];
            if (GameManager.Instance.shopInventory.GetItemList()[i] != null)
            {
                shopSlot.itemImage.style.backgroundImage = new StyleBackground(GameManager.Instance.shopInventory.GetItemList()[i].GetItemImage());
                shopSlot.quantityText.text = GameManager.Instance.shopInventory.GetItemList()[i].GetQuantity().ToString();
            }
            else
            {
                shopSlot.itemImage.style.backgroundImage = null;
                shopSlot.quantityText.text = "0";
            }
        }
    }

    void InventorySlotUpdate()
    {
        for (int i = 0; i < invSlots.Count; ++i)
        {
            if (GameManager.Instance.myInventory.GetItemList().Count <= i)
                return;
            Slot invSlot = invSlots[i];
            if (GameManager.Instance.myInventory.GetItemList()[i] != null)
            {
                invSlot.itemImage.style.backgroundImage = new StyleBackground(GameManager.Instance.myInventory.GetItemList()[i].GetItemImage());
                invSlot.quantityText.text = GameManager.Instance.myInventory.GetItemList()[i].GetQuantity().ToString();
            }
            else
            {
                invSlot.itemImage.style.backgroundImage = null;
                invSlot.quantityText.text = "0";
            }
        }
    }

    public override void UpdateControls()
    {
        ShopSlotUpdate();
        InventorySlotUpdate();
        ControllerUpdate();
        TotalCostUpdate();
        MyMoney.text = GameManager.Instance.myMoney.ToString() + "g";
    }
}
