using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTooltip : Window
{
    [SerializeField] private float dealyTimeOpen = 0.5f;
    [SerializeField] private Image renderTooltip;
    [SerializeField] private Image renderBackLight;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemDescription;
    private Coroutine coroutineDelayOpen = null;


    private void Update()
    {
        if (!gameObject.activeInHierarchy) return;
        transform.position = Input.mousePosition;
    }

    public override void Open()
    {
        transform.position = Input.mousePosition;
        gameObject.SetActive(true);
    }

    public void Open(Sprite sprite, string name, string description)
    {
        gameObject.SetActive(true);
        itemIcon.sprite = itemIcon.sprite;
        itemName.text = name;
        itemDescription.text = description;
        coroutineDelayOpen = StartCoroutine(DelayOpen());
    }

    public void Open(ref InventoryItem item)
    {
        gameObject.SetActive(true);
        itemIcon.sprite = item.ItemSprite;
        itemName.text = item.ItemName;
        itemDescription.text = item.ItemDescription;
        coroutineDelayOpen = StartCoroutine(DelayOpen());
    }

    public override void Close()
    {
        StopCoroutine(coroutineDelayOpen);
        SetShowComponents(false);
        gameObject.SetActive(false);
    }

    private void SetShowComponents(bool value)
    {
        renderTooltip.enabled = value;
        renderBackLight.enabled = value;
        itemIcon.enabled = value;
        itemName.enabled = value;
        itemDescription.enabled = value;
    }

    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(dealyTimeOpen);
        transform.position = Input.mousePosition;
        SetShowComponents(true);
        yield return null;
    }
}