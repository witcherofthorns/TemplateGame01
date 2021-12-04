using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IHitHandler
{
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private CharacterVisibleArea playerVisibleArea;
    [SerializeField] private CharacterStatusBars playerStatusBars;

    [Header("Inputs")]
    [SerializeField] private KeyCode pickupKey1;
    [SerializeField] private KeyCode inventoryKey1;
    [SerializeField] private KeyCode inventoryKey2;


    private void Start()
    {
        PlayerInit();
    }

    private void Update()
    {
        PlayerInputs();
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        PlayerRayCasting();
    }


    private void PlayerInit()
    {
        if (playerCamera)
        {
            playerCamera.SetLookAt(this.transform);
        }
    }

    private void PlayerInputs()
    {
        if(Input.mouseScrollDelta.y < 0)
        {
            playerCamera.ZoomOut();
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            playerCamera.ZoomIn();
        }
        if(Input.GetKeyDown(inventoryKey1) || Input.GetKeyDown(inventoryKey2))
        {
            if (GuiWindowsManager.Instance.IsInactiveWindows())
            {
                GuiWindowsManager.Instance.WindowInventory.Open(ref playerInventory);
            }
        }
        if(Input.GetKeyDown(pickupKey1))
        {
            if(playerVisibleArea)
            {
                if(playerVisibleArea.IsExistDetectItems<ItemObject>())
                {
                    PlayerPickUpItems();
                }
            }
        }
    }

    private void PlayerRayCasting()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCamera.CurrentCamera.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

        if (hit.collider != null)
        {
            LootObject tmp_lootobject = null;
            if (hit.collider.TryGetComponent<LootObject>(out tmp_lootobject))
            {
                PlayerLooting(tmp_lootobject);
            }
            // ...
        }
    }

    private void PlayerLooting(LootObject loot)
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(GuiWindowsManager.Instance.IsInactiveWindows())
            {
                GuiWindowsManager.Instance.WindowLoot.Open(playerInventory, loot.LootInventory);
            }
        }
    }


    private void PlayerPickUpItems()
    {
        GameObject[] tmp_objects = playerVisibleArea.GetArrayObjects;
        ItemObject tmp_item = null;

        for (int i = 0; i < tmp_objects.Length; i++)
        {
            if(tmp_objects[i].TryGetComponent<ItemObject>(out tmp_item))
            {
                playerInventory.AddItem(tmp_item);
            }
        }
    }

    private void PlayerMovement()
    {
        Movement(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    public void OnHit(uint damage)
    {

    }
}