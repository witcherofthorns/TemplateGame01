using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utils
{
    public static void LoadScene(string name)
    {
        Debug.Log("scene to load: " + name);
        SceneManager.LoadScene(name);
    }

    public static void LoadScene(int value)
    {
        Debug.Log("scene index to load: " + value);
        SceneManager.LoadScene(value);
    }
}