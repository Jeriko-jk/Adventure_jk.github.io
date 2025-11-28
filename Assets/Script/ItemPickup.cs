using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item itemData;                 // assign item di Inspector
    public InventoryUI inventoryUI;       // assign InventoryUI script
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D called with {other.name}");

        if (!other.CompareTag("Player"))
        {
            Debug.Log($"Collider is not Player: {other.name}");
            return;
        }

        Inventory inv = other.GetComponent<Inventory>();
        if (inv == null)
        {
            Debug.LogWarning("Player does not have Inventory script!");
            return;
        }

        if (itemData == null)
        {
            Debug.LogWarning("ItemPickup has no itemData assigned!");
            return;
        }

        Debug.Log($"Player picked up: {itemData.itemName}");

        // Tambahkan item ke inventory
        inv.AddItem(itemData);

        // Update UI
        if (inventoryUI != null)
        {
            inventoryUI.UpdateUI();
            Debug.Log("InventoryUI updated successfully.");
        }
        else
        {
            Debug.LogWarning("InventoryUI is not assigned!");
        }

        // Hapus pickup dari scene
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} destroyed after pickup.");
    }
}
