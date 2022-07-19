using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

   // int buttonNum = this.indexOf()
    public void LevelSelect1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Button Pressed!");
        
    }

    public void LevelSelect2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Button Pressed!");

    }

    public void LevelSelect3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Debug.Log("Button Pressed!");

    }

    public void LevelSelect4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        Debug.Log("Button Pressed!");

    }


    public void BackButton()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Button Pressed!");

    }

}
