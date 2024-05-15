using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject itemButtonPrefab;
    public Transform shopItemList;

    public void PopulateShop(Item[] items)
    {
        foreach (Transform child in shopItemList)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject button = Instantiate(itemButtonPrefab, shopItemList);
            button.GetComponentInChildren<Text>().text = $"{item.itemName} - {item.price} gold";
            button.GetComponent<Button>().onClick.AddListener(() => BuyItem(item));
        }
    }

    public void BuyItem(Item item)
    {
        // Check if player has enough gold (assuming you have a player gold management)
        playerInventory.AddItem(item);
        // Deduct gold from player
        // Optionally update UI
    }

    public void SellItem(Item item)
    {
        playerInventory.RemoveItem(item);
        // Add gold to player
        // Optionally update UI
    }
}
