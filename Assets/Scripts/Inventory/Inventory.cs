using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] private string nameInventory;
    [SerializeField] private uint sizeInventory;
    private InventoryItem[] items;

    public Action<uint> ActionInventoryAddItem;
    public Action<uint> ActionInventoryUseItem;
    public Action<uint> ActionInventoryRemoveItem;

    public string NameInventory { get => nameInventory; }
    public InventoryItem[] Items { get => items; }
    public uint SizeInventory { get => sizeInventory; }



    private void Awake()
    {
        InventoryCreate();
    }

    private void InventoryCreate()
    {
        if (sizeInventory > 0)
        {
            items = new InventoryItem[sizeInventory];
        }
        else Destroy(this);
    }

    public void AddItem(InventoryItem item)
    {
        uint index;

        if(isExistItem(item,out index))
        {
            items[index].ItemCount += item.ItemCount;
            ActionInventoryAddItem?.Invoke(index);
            return;
        }

        if(isFreedomSlot(out index))
        {
            items[index] = item;
            ActionInventoryAddItem?.Invoke(index);
            return;
        }
    }

    public void AddItem(ItemObject item)
    {
        uint index;

        if (isExistItem(item.Item, out index))
        {
            items[index].ItemCount += item.Item.ItemCount;
            ActionInventoryAddItem?.Invoke(index);
            Destroy(item.gameObject);
            return;
        }

        if (isFreedomSlot(out index))
        {
            items[index] = item.Item;
            ActionInventoryAddItem?.Invoke(index);
            Destroy(item.gameObject);
            return;
        }
    }

    public void AddItem(InventoryItem item, uint index)
    {
        if(items[index] == null)
        {
            items[index] = item;
        }
        else
        {
            if (items[index].ItemName == item.ItemName)
            {
                items[index].ItemCount += item.ItemCount;
            }
            else return;
        }
        ActionInventoryAddItem?.Invoke(index);
    }

    public void RemoveItem(uint index)
    {
        if(items[index] != null)
        {
            items[index] = null;
            ActionInventoryRemoveItem?.Invoke(index);
        }
    }

    public void UseItem(uint index, uint count)
    {
        if(items[index] != null)
        {
            if((items[index].ItemCount - count) <= 0)
            {
                RemoveItem(index);
                return;
            }
            items[index].ItemCount -= count;
            ActionInventoryUseItem?.Invoke(index);
        }
    }

    private bool isExistItem(InventoryItem item, out uint index)
    {
        for (uint i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                if (items[i].ItemName == item.ItemName)
                {
                    index = i;
                    return true;
                }
            }
        }

        index = 0;
        return false;
    }

    private bool isFreedomSlot(out uint index)
    {
        for (uint i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                index = i;
                return true;
            }
        }

        index = 0;
        return false;
    }
}