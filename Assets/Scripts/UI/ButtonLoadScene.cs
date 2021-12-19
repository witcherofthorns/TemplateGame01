using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoadScene : MonoBehaviour
{
    [SerializeField] private string nameScene;

    private void Start()
    {
        Button bttn;

        if(gameObject.TryGetComponent<Button>(out bttn))
        {
            bttn.onClick.AddListener(() =>
            {
                Utils.LoadScene(nameScene);
            });
        }
    }
}