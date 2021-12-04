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

    [SerializeField] private AnimationsEnvirovement envAnimations;
    [SerializeField] private DayTimeEnvirovement envDay;
}