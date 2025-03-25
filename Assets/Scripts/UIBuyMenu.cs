using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBuyMenu : Page
{
    [SerializeField]
    Sprite item1Icon;
    [SerializeField]
    Sprite item2Icon;
    [SerializeField]
    Sprite item3Icon;

    private Button _itemButton1;
    private Button _decreaseButton1;
    private Button _increaseButton1;
    private Label _quantityLabel1;
    private Label _priceLabel1;

    private Button _itemButton2;
    private Button _decreaseButton2;
    private Button _increaseButton2;
    private Label _quantityLabel2;
    private Label _priceLabel2;

    private Button _itemButton3;
    private Button _decreaseButton3;
    private Button _increaseButton3;
    private Label _quantityLabel3;
    private Label _priceLabel3;

    private Label _invItem1Amount;
    private Label _invItem2Amount;
    private Label _invItem3Amount;
    private Label _myMoney;

    private Button _buyButton;
    private Button _backButton;

    private Label _totalLabel;
    private VisualElement _itemIcon;
    private Label _itemName;
    private Label _itemDesc;
    int item1Quantity = 0;
    int item2Quantity = 0;
    int item3Quantity = 0;
    int totalPrice = 0;

    private void Awake()
    {
        int screenW = 1280;
        int screenH = 960;
        bool isFullScreen = false;
        Screen.SetResolution(screenW, screenH, isFullScreen);
    }

    void Start()
    {
        _root = doc.rootVisualElement;

        _quantityLabel1 = _root.Q<Label>("QuantityLabel1");
        _decreaseButton1 = _root.Q<Button>("QuantityDecrease1");
        _increaseButton1 = _root.Q<Button>("QuantityIncrease1");
        _priceLabel1 = _root.Q<Label>("PriceLabel1");
        _itemButton1 = _root.Q<Button>("ShopButton1");

        _quantityLabel2 = _root.Q<Label>("QuantityLabel2");
        _decreaseButton2 = _root.Q<Button>("QuantityDecrease2");
        _increaseButton2 = _root.Q<Button>("QuantityIncrease2");
        _priceLabel2 = _root.Q<Label>("PriceLabel2");
        _itemButton2 = _root.Q<Button>("ShopButton2");

        _quantityLabel3 = _root.Q<Label>("QuantityLabel3");
        _decreaseButton3 = _root.Q<Button>("QuantityDecrease3");
        _increaseButton3 = _root.Q<Button>("QuantityIncrease3");
        _priceLabel3 = _root.Q<Label>("PriceLabel3");
        _itemButton3 = _root.Q<Button>("ShopButton3");

        _invItem1Amount = _root.Q<Label>("InvItem1Amount");
        _invItem2Amount = _root.Q<Label>("InvItem2Amount");
        _invItem3Amount = _root.Q<Label>("InvItem3Amount");

        _myMoney = _root.Q<Label>("MyMoney");
        _totalLabel = _root.Q<Label>("TotalLabel");
        _itemIcon = _root.Q<VisualElement>("ItemIcon");
        _itemName = _root.Q<Label>("ItemName");
        _itemDesc = _root.Q<Label>("ItemDesc");

        _buyButton = _root.Q<Button>("BuyButton");
        _backButton = _root.Q<Button>("BackButton");

        _itemButton1.RegisterCallback<ClickEvent>(SelectItem1);
        _decreaseButton1.RegisterCallback<ClickEvent>(DecreaseButton1);
        _increaseButton1.RegisterCallback<ClickEvent>(IncreaseButton1);

        _itemButton2.RegisterCallback<ClickEvent>(SelectItem2);
        _decreaseButton2.RegisterCallback<ClickEvent>(DecreaseButton2);
        _increaseButton2.RegisterCallback<ClickEvent>(IncreaseButton2);

        _itemButton3.RegisterCallback<ClickEvent>(SelectItem3);
        _decreaseButton3.RegisterCallback<ClickEvent>(DecreaseButton3);
        _increaseButton3.RegisterCallback<ClickEvent>(IncreaseButton3);

        _buyButton.RegisterCallback<ClickEvent>(BuyButton);
        UpdateQuantity();


        _root.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        _myMoney.text = GameManager.Instance.myMoney.ToString() + "g";

        int item1Price = Convert.ToInt32(_priceLabel1.text.Substring(0, _priceLabel1.text.Length - 1).ToString());
        int item1Quantity = Convert.ToInt32(_quantityLabel1.text.Substring(1, _quantityLabel1.text.Length-1).ToString());
        int item2Price = Convert.ToInt32(_priceLabel2.text.Substring(0, _priceLabel2.text.Length - 1).ToString());
        int item2Quantity = Convert.ToInt32(_quantityLabel2.text.Substring(1, _quantityLabel2.text.Length - 1).ToString());
        int item3Price = Convert.ToInt32(_priceLabel3.text.Substring(0, _priceLabel3.text.Length - 1).ToString());
        int item3Quantity = Convert.ToInt32(_quantityLabel3.text.Substring(1, _quantityLabel3.text.Length - 1).ToString());
        totalPrice = item1Price * item1Quantity + item2Price * item2Quantity + item3Price * item3Quantity;
        _totalLabel.text = "Total: " + totalPrice.ToString() + "g";
    }
    private void IncreaseButton1(ClickEvent clickEvent)
    {
        ++item1Quantity;
        if (item1Quantity > 9)
            item1Quantity = 9;
        UpdateQuantity();
    }
    private void DecreaseButton1(ClickEvent clickEvent)
    {
        --item1Quantity;
        if (item1Quantity < 0)
            item1Quantity = 0;
        UpdateQuantity();
    }
    private void IncreaseButton2(ClickEvent clickEvent)
    {
        ++item2Quantity;
        if (item2Quantity > 9)
            item2Quantity = 9;
        UpdateQuantity();
    }
    private void DecreaseButton2(ClickEvent clickEvent)
    {
        --item2Quantity;
        if (item2Quantity < 0)
            item2Quantity = 0;
        UpdateQuantity();
    }
    private void IncreaseButton3(ClickEvent clickEvent)
    {
        ++item3Quantity;
        if (item3Quantity > 9)
            item3Quantity = 9;
        UpdateQuantity();
    }
    private void DecreaseButton3(ClickEvent clickEvent)
    {
        --item3Quantity;
        if (item3Quantity < 0)
            item3Quantity = 0;
        UpdateQuantity();
    }
    private void BuyButton(ClickEvent clickEvent)
    {
        int item1Price = Convert.ToInt32(_priceLabel1.text.Substring(0, _priceLabel1.text.Length - 1).ToString());
        int item1Quantity = Convert.ToInt32(_quantityLabel1.text.Substring(1, _quantityLabel1.text.Length - 1).ToString());
        int item2Price = Convert.ToInt32(_priceLabel2.text.Substring(0, _priceLabel2.text.Length - 1).ToString());
        int item2Quantity = Convert.ToInt32(_quantityLabel2.text.Substring(1, _quantityLabel2.text.Length - 1).ToString());
        int item3Price = Convert.ToInt32(_priceLabel3.text.Substring(0, _priceLabel3.text.Length - 1).ToString());
        int item3Quantity = Convert.ToInt32(_quantityLabel3.text.Substring(1, _quantityLabel3.text.Length - 1).ToString());
        totalPrice = item1Price * item1Quantity + item2Price * item2Quantity + item3Price * item3Quantity;

        if (GameManager.Instance.myMoney >= totalPrice)
        {
            GameManager.Instance.myMoney -= totalPrice;
            Reset();
        }
    }
    private void Reset()
    {
        item1Quantity = 0;
        item2Quantity = 0;
        item3Quantity = 0;
        UpdateQuantity();

    }
    private void SelectItem1(ClickEvent clickEvent)
    {
        _itemButton1.style.borderBottomWidth = 4.0f;
        _itemButton1.style.borderLeftWidth = 4.0f;
        _itemButton1.style.borderTopWidth = 4.0f;
        _itemButton1.style.borderRightWidth = 4.0f;

        _itemButton2.style.borderBottomWidth = 0.0f;
        _itemButton2.style.borderLeftWidth = 0.0f;
        _itemButton2.style.borderTopWidth = 0.0f;
        _itemButton2.style.borderRightWidth = 0.0f;

        _itemButton3.style.borderBottomWidth = 0.0f;
        _itemButton3.style.borderLeftWidth = 0.0f;
        _itemButton3.style.borderTopWidth = 0.0f;
        _itemButton3.style.borderRightWidth = 0.0f;

        _itemIcon.style.backgroundImage = new StyleBackground(item1Icon.texture);
        _itemName.text = "Sweet";
        _itemDesc.text = "A sweet manifactured with natural healing properties.\n+10HP";
    }
    private void SelectItem2(ClickEvent clickEvent)
    {
        _itemButton1.style.borderBottomWidth = 0.0f;
        _itemButton1.style.borderLeftWidth = 0.0f;
        _itemButton1.style.borderTopWidth = 0.0f;
        _itemButton1.style.borderRightWidth = 0.0f;

        _itemButton2.style.borderBottomWidth = 4.0f;
        _itemButton2.style.borderLeftWidth = 4.0f;
        _itemButton2.style.borderTopWidth = 4.0f;
        _itemButton2.style.borderRightWidth = 4.0f;

        _itemButton3.style.borderBottomWidth = 0.0f;
        _itemButton3.style.borderLeftWidth = 0.0f;
        _itemButton3.style.borderTopWidth = 0.0f;
        _itemButton3.style.borderRightWidth = 0.0f;

        _itemIcon.style.backgroundImage = new StyleBackground(item2Icon.texture);
        _itemName.text = "Chocolate";
        _itemDesc.text = "A rich and creamy choclate bar infused with crunchy caramel bits.\n+50HP";
    }
    private void SelectItem3(ClickEvent clickEvent)
    {
        _itemButton1.style.borderBottomWidth = 0.0f;
        _itemButton1.style.borderLeftWidth = 0.0f;
        _itemButton1.style.borderTopWidth = 0.0f;
        _itemButton1.style.borderRightWidth = 0.0f;

        _itemButton2.style.borderBottomWidth = 0.0f;
        _itemButton2.style.borderLeftWidth = 0.0f;
        _itemButton2.style.borderTopWidth = 0.0f;
        _itemButton2.style.borderRightWidth = 0.0f;

        _itemButton3.style.borderBottomWidth = 4.0f;
        _itemButton3.style.borderLeftWidth = 4.0f;
        _itemButton3.style.borderTopWidth = 4.0f;
        _itemButton3.style.borderRightWidth = 4.0f;

        _itemIcon.style.backgroundImage = new StyleBackground(item3Icon.texture);
        _itemName.text = "Faeri Walnut";
        _itemDesc.text = "A mystical nut that restores energy and enhances magical power.\n+40MP";
    }

    void UpdateQuantity()
    {
        _quantityLabel1.text = "X" + item1Quantity.ToString();
        _quantityLabel2.text = "X" + item2Quantity.ToString();
        _quantityLabel3.text = "X" + item3Quantity.ToString();
    }

    public override void UpdateControls()
    {
    }
}
