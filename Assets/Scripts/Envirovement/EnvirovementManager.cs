using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirovementManager : MonoBehaviour
{
    #region Singletone
    private static EnvirovementManager singletone = null;
    public static EnvirovementManager Instance { get => singletone; }
    private void Awake()
    {
        lock (this)
        {
            if (singletone == null)
            {
                singletone = this;
            }
            else Destroy(this);
        }
    }
    #endregion

    [Header("Parametrs")]
    [SerializeField, Range(0.1f,1.5f)] private float grassAnimSpeed;

    [Header("Objects")]
    [SerializeField] private GrassEnvirovement[] grass;


    private void Start()
    {
        GetEnvirovementObjects();
        StartCoroutine(GrassWindAnimation());
    }

    private void GetEnvirovementObjects()
    {
        grass = FindObjectsOfType<GrassEnvirovement>();
    }

    IEnumerator GrassWindAnimation()
    {
        while (true)
        {
            for (int i = 0; i < grass.Length; i++)
            {
                grass[i].FrameAnimator.NextAnimationFrame();
            }
            yield return new WaitForSeconds(grassAnimSpeed);
        }
        yield return null;
    }
}