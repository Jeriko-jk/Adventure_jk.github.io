using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // List item Player

    // Tambah item ke inventory
    public void AddItem(Item newItem)
    {
    if (newItem == null)
    {
        Debug.LogWarning("Tried to add null item to inventory!");
        return; // jangan tambahkan ke list
    }

    Item existingItem = items.Find(i => i != null && i.itemName == newItem.itemName);
    if (existingItem != null)
        existingItem.quantity += newItem.quantity;
    else
        items.Add(newItem);

    Debug.Log($"Added {newItem.itemName}, total: {newItem.quantity}");
    }


    // Hapus item
    public void RemoveItem(string itemName, int amount = 1)
    {
        if (items == null)
            return;

        Item existingItem = items.Find(i => i != null && i.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.quantity -= amount;
            if (existingItem.quantity <= 0)
                items.Remove(existingItem);
        }
    }
}
