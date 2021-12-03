using UnityEngine;
using UnityEngine.UI;

public class InventoryGhostCell : MonoBehaviour
{
    [SerializeField] private Image render;
    [SerializeField] private Text count;
    private Inventory tmp_inventory;
    private InventoryItem tmp_item;
    private uint tmp_index;

    public InventoryItem Item { get => tmp_item; }

    public void Create(ref Inventory targetInventory, uint targetIndex)
    {
        tmp_inventory = targetInventory;
        tmp_index = targetIndex;
        tmp_item = Instantiate(tmp_inventory.Items[tmp_index]);

        render.sprite = tmp_item.ItemSprite;
        count.text = tmp_item.ItemCount.ToString();
        gameObject.SetActive(true);

        transform.position = Input.mousePosition;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void Remove()
    {
        tmp_inventory = null;
        tmp_index = 0;
        tmp_item = null;
        render.sprite = null;
        gameObject.SetActive(false);
    }
}