using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : Window
{
    [SerializeField] private Button bttnCloseWindow;
    [SerializeField] private Text textInventoryName;
    [SerializeField] private InventoryCell[] cellsPool;
    private Inventory targetInventory;


    public override void Open()
    {
        if(bttnCloseWindow) bttnCloseWindow.onClick.AddListener(() => { Close(); });
        textInventoryName.text = "NULL";
        gameObject.SetActive(true);
    }

    public void Open(ref Inventory inventory)
    {
        if (gameObject.activeInHierarchy)
        {
            return;
        }


        HideAllCells();

        targetInventory = inventory;
        targetInventory.ActionInventoryAddItem += ActionAddItemCell;
        targetInventory.ActionInventoryUseItem += ActionUsedItemCell;
        targetInventory.ActionInventoryRemoveItem += ActionRemoveItemCell;

        if (bttnCloseWindow) bttnCloseWindow.onClick.AddListener(() => { Close(); });
        textInventoryName.text = targetInventory.NameInventory;

        for (uint i = 0; i < targetInventory.SizeInventory; i++)
        {
            cellsPool[i].gameObject.SetActive(true);
            cellsPool[i].CreateCell(i, ref targetInventory);
        }

        gameObject.SetActive(true);
    }

    public override void Close()
    {
        targetInventory.ActionInventoryAddItem -= ActionAddItemCell;
        targetInventory.ActionInventoryUseItem -= ActionUsedItemCell;
        targetInventory.ActionInventoryRemoveItem -= ActionRemoveItemCell;

        if (bttnCloseWindow) bttnCloseWindow.onClick.RemoveAllListeners();
        textInventoryName.text = null;

        for (uint i = 0; i < cellsPool.Length; i++)
        {
            cellsPool[i].RemoveCell();
            cellsPool[i].gameObject.SetActive(false);
        }

        targetInventory = null;
        gameObject.SetActive(false);
    }

    private void HideAllCells()
    {
        for (uint i = 0; i < cellsPool.Length; i++)
        {
            cellsPool[i].gameObject.SetActive(false);
        }
    }

    private void ActionAddItemCell(uint index)
    {
        if(targetInventory.Items[index] == null)
        {
            cellsPool[index].CreateCell(index, ref targetInventory);
        }
        else cellsPool[index].UpdateCell();
    }

    private void ActionUsedItemCell(uint index)
    {
        cellsPool[index].UpdateCell();
    }

    private void ActionRemoveItemCell(uint index)
    {
        cellsPool[index].HideCell();
    }
}