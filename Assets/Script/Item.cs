using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;  // Nama item
    public Sprite icon;      // Icon yang muncul di inventory
    public int quantity = 1; // Jumlah item
}
