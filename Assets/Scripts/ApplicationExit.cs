using UnityEngine;
using UnityEngine.InputSystem;

public class ApplicationExit : MonoBehaviour
{
    void Update()
    {
        OnApplicationQuit();
    }

    void OnApplicationQuit()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
