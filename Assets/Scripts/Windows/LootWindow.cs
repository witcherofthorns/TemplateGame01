using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootWindow : Window
{
    [SerializeField] private Button bttnClose;
    [SerializeField] private InventoryWindow characterInventoryWindow;
    [SerializeField] private InventoryWindow lootInventoryWindow;

    public override void Open()
    {
    }

    public void Open(Inventory character, Inventory lootInventory)
    {
        if (bttnClose) bttnClose.onClick.AddListener(() => { Close(); });
        gameObject.SetActive(true);
        characterInventoryWindow.Open(ref character);
        lootInventoryWindow.Open(ref lootInventory);
        isOpen = true;
    }

    public override void Close()
    {
        if (bttnClose) bttnClose.onClick.RemoveAllListeners();
        characterInventoryWindow.Close();
        lootInventoryWindow.Close();
        gameObject.SetActive(false);
        isOpen = false;
    }
}
