using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeEnvirovement : MonoBehaviour
{
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    [SerializeField] private Season season;
    [SerializeField] private float dayTime;
    [SerializeField] private float nightTimeDelay;
    [SerializeField] private bool nightDelay;
    [SerializeField,Range(0.1f,1.5f)] private float dayTimeSpeed;
    [SerializeField] private Material mainMaterial;
    [SerializeField] private Gradient gradientDay;


    private void Start()
    {
        StartCoroutine(DayTimeUpdate());
    }

    private void DayTimeTick()
    {
        if (dayTime < 24.0f)
        {
            dayTime += 0.1f;
        }
        else
        {
            dayTime = 0;
            nightDelay = true;
        }
    }

    private void DrawDayMaterial()
    {
        mainMaterial.color = gradientDay.Evaluate(dayTime / 24f);
    }

    IEnumerator DayTimeUpdate()
    {
        while (true)
        {
            if (nightDelay)
            {
                yield return new WaitForSeconds(nightTimeDelay);
                nightDelay = false;
            }

            DayTimeTick();
            DrawDayMaterial();
            yield return new WaitForSeconds(dayTimeSpeed);
        }
        yield return null;
    }

    private void OnValidate()
    {
        mainMaterial.color = Color.white;
    }
}