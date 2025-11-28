using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory;   // assign Player Inventory
    public GameObject slotPrefab;       // assign SlotPrefab
    public Transform slotParent;        // assign Panel_Inventory

    public void UpdateUI()
{
    Debug.Log("UpdateUI called");

    // 1️⃣ Cek referensi utama
    if(playerInventory == null)
    {
        Debug.LogWarning("Player Inventory is null!");
        return;
    }

    if(slotPrefab == null)
    {
        Debug.LogWarning("Slot Prefab is null!");
        return;
    }

    if(slotParent == null)
    {
        Debug.LogWarning("Slot Parent is null!");
        return;
    }

    // 2️⃣ Bersihkan slot lama
    foreach(Transform child in slotParent)
        Destroy(child.gameObject);
    Debug.Log("Cleared old slots");

    // 3️⃣ Cek inventory kosong
    if(playerInventory.items == null || playerInventory.items.Count == 0)
    {
        Debug.Log("Player inventory is empty");
        return;
    }

    // 4️⃣ Tambahkan slot baru
    for(int i = 0; i < playerInventory.items.Count; i++)
    {
        Item item = playerInventory.items[i];
        if(item == null)
        {
            Debug.LogWarning($"Item at index {i} is null!");
            continue;
        }

        GameObject slot = Instantiate(slotPrefab, slotParent);
        if(slot == null)
        {
            Debug.LogWarning("Failed to instantiate slotPrefab!");
            continue;
        }

        Image slotImage = slot.GetComponent<Image>();
        if(slotImage != null)
        {
            if(item.icon != null)
            {
                slotImage.sprite = item.icon;
                slotImage.enabled = true;
            }
            else
            {
                Debug.LogWarning($"Item {item.itemName} icon is null!");
                slotImage.enabled = false;
            }
        }
        else
        {
            Debug.LogWarning("SlotPrefab missing Image component!");
        }

        Debug.Log($"Added item '{item.itemName}' to UI, quantity: {item.quantity}");
    }

    Debug.Log("UpdateUI finished");
}
}
