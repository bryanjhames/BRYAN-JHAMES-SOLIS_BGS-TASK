using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject shopItemPrefab;
    public Transform shopItemContainer;
    public Item[] itemsForSale;

    public TMP_Text playerCoinsText;

    private PlayerDataManager dataManager;
    private PlayerDataUI playerDataUI;

    private void Start()
    {
        dataManager = PlayerDataManager.Instance;
        playerDataUI = FindObjectOfType<PlayerDataUI>();

        InitializeShop();
        UpdatePlayerCoinsUI();

        dataManager.OnDataChanged += UpdatePlayerCoinsUI; // Subscribe to the data change event
    }

    private void OnDestroy()
    {
        dataManager.OnDataChanged -= UpdatePlayerCoinsUI; // Unsubscribe from the event
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
        if (dataManager.playerData.coins >= item.price)
        {
            dataManager.SpendCoins(item.price);
            Debug.Log("Purchased: " + item.itemName);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    private void UpdatePlayerCoinsUI()
    {
        playerCoinsText.text = "Coins: " + dataManager.playerData.coins.ToString();
        playerDataUI.UpdateUI();
    }
}
