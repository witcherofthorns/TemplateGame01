using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class LootItemObject
{
    [SerializeField] private InventoryItem item;
    [SerializeField, Range(1,128)] private byte count;

    public InventoryItem Item { get => item; }
    public byte Count { get => count; }
}

public class LootObject : MonoBehaviour
{
    [SerializeField] private LootItemObject[] items;
    [SerializeField] private Inventory lootInventory;

    public Inventory LootInventory { get => lootInventory; }



    private void Start()
    {
        LootCloneOrigialItems();
    }

    private void LootHoverLight()
    {

    }

    private void LootCloneOrigialItems()
    {
        List<InventoryItem> tmp_items = new List<InventoryItem>();

        for (byte i = 0; i < items.Length; i++)
        {
            if (items[i].Item == null)
            {
                continue;
            }

            InventoryItem tmp_item = Instantiate(items[i].Item);
            tmp_item.ItemCount = items[i].Count;
            tmp_items.Add(tmp_item);
        }

        LootAddItemsInventory(ref tmp_items);
        return;
    }

    private void LootAddItemsInventory(ref List<InventoryItem> cloneItems)
    {
        for (int i = 0; i < cloneItems.Count; i++)
        {
            lootInventory.AddItem(cloneItems[i]);
        }

        return;
    }
}