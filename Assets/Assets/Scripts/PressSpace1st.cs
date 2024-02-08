using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PressSpace1st : MonoBehaviour{
    bool is1stPagePressed;  
    void Start()
    {

    }

    void Update()
    {
        if(is1stPagePressed)
        {
            GoToNextScene();
        }
    }
    void GoToNextScene()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }    

   private void OnFirstPage(InputValue input)
    {
        is1stPagePressed = input.isPressed;
    } 
}


