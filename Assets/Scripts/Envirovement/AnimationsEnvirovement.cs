using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEnvirovement : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField, Range(0.1f, 1.5f)] private float grassAnimSpeed;
    [SerializeField, Range(0.1f, 1.5f)] private float waterAnimSpeed;

    [Header("Objects")]
    [SerializeField] private GrassEnvirovement[] grass;
    [SerializeField] private WaterEnvirovement[] waters;


    private void Start()
    {
        GetEnvirovementObjects();
        StartCoroutine(GrassWindAnimation());
        StartCoroutine(WaterWindAnimation());
    }

    private void GetEnvirovementObjects()
    {
        grass = FindObjectsOfType<GrassEnvirovement>();
        waters = FindObjectsOfType<WaterEnvirovement>();
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
    }

    IEnumerator WaterWindAnimation()
    {
        while (true)
        {
            for (int i = 0; i < waters.Length; i++)
            {
                waters[i].FrameAnimator.NextAnimationFrame();
            }
            yield return new WaitForSeconds(waterAnimSpeed);
        }
    }
}
