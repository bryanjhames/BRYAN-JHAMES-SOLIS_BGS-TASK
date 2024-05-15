using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    public ItemType itemType;
}

public enum ItemType
{
    Hat,
    Clothes,
    Pants,
    Shoes
}
