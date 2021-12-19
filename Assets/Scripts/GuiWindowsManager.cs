using UnityEngine;
using UnityEngine.UI;

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
                //DontDestroyOnLoad(gameObject);
            }
            else Destroy(this);
        }
    }
    #endregion

    [Header("Objects")]
    [SerializeField] private GameObject playerObjectText;
    [SerializeField] private Text playerActionText;
    [SerializeField] private InventoryGhostCell ghostCell;
    [SerializeField] private InventoryTooltip tooltip;

    [Header("Windows")]
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
    public bool IsInactiveWindows()
    {
        if(!inventoryWindow.IsOpen && !lootWindow.IsOpen)
        {
            return true;
        }
        return false;
    }

    public void SetPlayerActionTextActivate(bool active)
    {
        playerObjectText.gameObject.SetActive(active);
    }

    public void SetPlayerActionText(string text)
    {
        playerActionText.text = text;
    }
}