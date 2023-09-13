using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerToMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
