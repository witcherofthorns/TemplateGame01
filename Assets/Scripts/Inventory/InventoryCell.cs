using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Text itemCountText;
    private Inventory inventory;
    private uint index;


    public void CreateCell(uint index, ref Inventory inventory)
    {
        this.index = index;
        this.inventory = inventory;
        UpdateCell();
    }

    public void UpdateCell()
    {
        if (inventory.Items[index] != null)
        {
            itemIcon.sprite = inventory.Items[index].ItemSprite;
            itemCountText.text = inventory.Items[index].ItemCount.ToString();
            itemIcon.enabled = true;
            itemCountText.enabled = true;
        }
        else
        {
            HideCell();
        }
    }

    public void HideCell()
    {
        itemIcon.sprite = null;
        itemCountText.text = null;
        itemIcon.enabled = false;
        itemCountText.enabled = false;
    }

    public void RemoveCell()
    {
        inventory = null;
        index = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!GuiWindowsManager.Instance.IsActiveGhostCell)
        {
            GuiWindowsManager.Instance.GhostCell.Create(ref inventory, index);
            inventory.RemoveItem(index);
        }
        else
        {
            if (inventory.Items[index] != null)
            {
                if (GuiWindowsManager.Instance.GhostCell.Item.ItemName == inventory.Items[index].ItemName)
                {
                    inventory.AddItem(GuiWindowsManager.Instance.GhostCell.Item, index);
                    GuiWindowsManager.Instance.GhostCell.Remove();
                }
            }
            else
            {
                inventory.AddItem(GuiWindowsManager.Instance.GhostCell.Item, index);
                GuiWindowsManager.Instance.GhostCell.Remove();
            }

            return;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}