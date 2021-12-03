using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiWindowsManager : MonoBehaviour
{
    #region Singletone
    private static GuiWindowsManager singletone;
    public static GuiWindowsManager Instance { get => singletone; }
    public InventoryWindow InventoryWindow { get => inventoryWindow; set => inventoryWindow = value; }

    private void Awake()
    {
        lock (this)
        {
            if (singletone == null)
            {
                singletone = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(this);
        }
    }
    #endregion

    [SerializeField] private InventoryGhostCell ghostCell;
    [SerializeField] private InventoryTooltip tooltip;

    [SerializeField] private InventoryWindow inventoryWindow;
    [SerializeField] private LootWindow lootWindow;

    public InventoryWindow WindowInventory { get => inventoryWindow; }
    public LootWindow WindowLoot { get => lootWindow; }
    public InventoryGhostCell GhostCell { get => ghostCell; }
    public InventoryTooltip Tooltip { get => tooltip; }


    public bool IsActiveGhostCell
    {
        get
        {
            if(ghostCell)
            {
                return ghostCell.isActiveAndEnabled;
            }
            return false;
        }
    }
}