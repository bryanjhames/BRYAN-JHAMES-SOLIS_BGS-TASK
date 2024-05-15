using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    private Item item;
    private ShopManager shopManager;

    public void Initialize(Item newItem, ShopManager manager)
    {
        item = newItem;
        shopManager = manager;
        icon.sprite = item.icon;
        itemNameText.text = item.itemName;
        priceText.text = item.price.ToString() + " Coins";
    }

    public void OnPurchaseButtonClicked()
    {
        shopManager.PurchaseItem(item);
    }
}
