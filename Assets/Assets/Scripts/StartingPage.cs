using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class StartingPage : MonoBehaviour
{
    public UIDocument uidoc;
    public LoadingPage loadpage;
    VisualElement Starting;

    void Start()
    {
        
        VisualElement root = uidoc.rootVisualElement;
        Starting = root.Q<VisualElement>("Starting");
        Starting.style.display = DisplayStyle.Flex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Starting.style.display = DisplayStyle.None;
            loadpage.setdisplay(true);
            enabled = false;
        }
    }
}
