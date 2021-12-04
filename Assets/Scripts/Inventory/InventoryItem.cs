using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Game/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private uint itemCount = 1;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemDescription;


    public string ItemName { get => itemName; }
    public uint ItemCount { get => itemCount; set => itemCount = value; }
    public Sprite ItemSprite { get => itemSprite; }
    public string ItemDescription { get => itemDescription; }
}