using Mirror;
using Mirror.Authenticators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRoomWindow : MonoBehaviour
{
    [SerializeField] private NetworkManager netManager;
    [SerializeField] private BasicAuthenticator netAuth;
    [SerializeField] private InputField ipadressField;
    [SerializeField] private InputField usernameField;

    [Header("Preview")]
    [SerializeField] private Text previewStartHost;
    [SerializeField] private Text previewStartClient;


    public void SetNetworkAdress()
    {
        netManager.networkAddress = ipadressField.text;
    }

    public void SetAuthPlayerName()
    {
        netAuth.username = usernameField.text;
    }

    public void StartNetworkGame()
    {
        StartCoroutine(StartNetworkGameDelay());
    }

    public void StartNetworkClient()
    {
        StartCoroutine(StartNetworkClientDelay());
    }

    private IEnumerator StartNetworkClientDelay()
    {
        DontDestroyOnLoad(netManager.gameObject);
        previewStartHost.text = "connection...";
        yield return new WaitForSeconds(1);
        previewStartHost.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        netManager.StartClient();
        yield return null;
    }

    private IEnumerator StartNetworkGameDelay()
    {
        DontDestroyOnLoad(netManager.gameObject);
        previewStartHost.text = "well, let's try";
        yield return new WaitForSeconds(1);
        previewStartHost.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        netManager.StartHost();
        yield return null;
    }
}