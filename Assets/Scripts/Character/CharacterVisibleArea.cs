using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterVisibleArea : MonoBehaviour
{
    [SerializeField] private bool lightDetectItems;
    [SerializeField] LayerMask layerDetectCheck;
    [SerializeField, Range(0.1f,1.0f)] private float delayTimeCheck;
    [SerializeField, Range(0.3f, 2.5f)] private float areaDistanceValue;
    [SerializeField] private List<GameObject> visiblePollObjects;

    public List<GameObject> GetListObjects 
    {
        get
        {
            return visiblePollObjects;
        }
    }
    public GameObject[] GetArrayObjects
    {
        get 
        {
            GameObject[] tmp_array = visiblePollObjects.ToArray();
            return tmp_array;
        }
    }


    private void Awake()
    {
        visiblePollObjects = new List<GameObject>();
    }

    private void Start()
    {
        StartCoroutine(AreaCheckObjects());
    }

    public void OnDestroy()
    {
        StopCoroutine(AreaCheckObjects());
    }

    public bool IsExistDetectItems<T>()
    {
        if(visiblePollObjects.Count == 0)
        {
            return false;
        }

        for (byte i = 0; i < visiblePollObjects.Count; i++)
        {
            if(visiblePollObjects[i] != null)
            {
                if (visiblePollObjects[i].GetComponent<T>() != null)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void AreaDetectObjects()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, areaDistanceValue, layerDetectCheck);

        visiblePollObjects.Clear();

        for (byte i = 0; i < colls.Length; i++)
        {
            if(colls[i].gameObject == this.gameObject)
            {
                continue;
            }
            visiblePollObjects.Add(colls[i].gameObject);
        }
    }

    // just effect
    private void ShowLightDetectItems(bool value)
    {
        if (lightDetectItems)
        {
            return;
        }

        for (byte i = 0; i < visiblePollObjects.Count; i++)
        {
            if(visiblePollObjects[i] != null)
            {
                ItemObject tmp_item = null;
                if (visiblePollObjects[i].TryGetComponent<ItemObject>(out tmp_item))
                {
                    tmp_item.OnFocusLight(value);
                }
            }
        }
    }

    private IEnumerator AreaCheckObjects()
    {
        while (true)
        {
            AreaDetectObjects();
            ShowLightDetectItems(true);
            yield return new WaitForSeconds(delayTimeCheck);
            ShowLightDetectItems(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, areaDistanceValue);
    }
}