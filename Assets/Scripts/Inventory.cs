using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        // Optionally update the UI
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // Optionally update the UI
    }
}
