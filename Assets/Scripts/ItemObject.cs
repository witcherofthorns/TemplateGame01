using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private SpriteRenderer light;
    [SerializeField] private Animator animator;
    [SerializeField] private InventoryItem item;

    public InventoryItem Item { get => item; }

    void Start()
    {
        if(!item)
        {
            Destroy(gameObject);
            return;
        }

        render.sprite = item.ItemSprite;
        animator.enabled = true;
        item = Instantiate(item); // clone original
    }

    public void OnFocusLight(bool value)
    {
        if(light)
        {
            light.enabled = value;
        }
    }
}
