using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    [SerializeField] public Button[] buttons;
    
    


    void Update()
    {
       // Debug.Log("curlevel" + curLevel);

        
    }

    void Start()
    {
        /*
        int curLevel = PlayerPrefs.GetInt("levelAt", 2);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            //2 because the build index of level select is 2
            if (i + 2 > curLevel)
            {
                buttons[i].interactable = false;
            }
        }

        */

    }

    
}
    




