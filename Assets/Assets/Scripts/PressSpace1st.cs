using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PressSpace1st : MonoBehaviour{

    public UIDocument uidoc;
    public float a = 0;
    VisualElement image;
    
    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        image= root.Q<VisualElement>("ImageLoad");
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextScene();
        }
        image.style.rotate = new StyleRotate(new Rotate(new Angle(a)));
    }
    void GoToNextScene()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }    


}
