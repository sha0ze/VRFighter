using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScene : MonoBehaviour
{
    public void quitScene()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}