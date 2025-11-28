using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public InventoryUI inventoryUI; // assign InventoryUI script

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);

            if(isOpen && inventoryUI != null)
            {
                inventoryUI.UpdateUI(); // update slot ketika panel muncul
            }
        }
    }
}
