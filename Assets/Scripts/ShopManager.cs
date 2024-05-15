using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject shopItemPrefab;
    public Transform shopItemContainer;
    public Item[] itemsForSale;

    public TMP_Text playerCoinsText;
    private int playerCoins = 1000; // Example starting coins

    private void Start()
    {
        InitializeShop();
        UpdatePlayerCoinsUI();
    }

    private void InitializeShop()
    {
        foreach (Item item in itemsForSale)
        {
            GameObject shopItemObject = Instantiate(shopItemPrefab, shopItemContainer);
            ShopItemUI shopItemUI = shopItemObject.GetComponent<ShopItemUI>();
            shopItemUI.Initialize(item, this);
        }
    }

    public void PurchaseItem(Item item)
    {
        if (playerCoins >= item.price)
        {
            playerCoins -= item.price;
            UpdatePlayerCoinsUI();
            Debug.Log("Purchased: " + item.itemName);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    private void UpdatePlayerCoinsUI()
    {
        playerCoinsText.text = "Coins: " + playerCoins.ToString();
    }
}
