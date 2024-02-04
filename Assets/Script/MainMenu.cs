using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayNormal()
    {
        SceneManager.LoadScene(1);
    }
    
    public void PlayCredits()
    {
        SceneManager.LoadScene(2);
    }
    
    public void PlayGlobalWarming()
    {
        SceneManager.LoadScene(3);
    }
    
    
}

