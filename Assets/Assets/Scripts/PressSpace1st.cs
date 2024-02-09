using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PressSpace1st : MonoBehaviour
{
    public UIDocument uidoc;
    public float a=0;
    VisualElement image;
    VisualElement image1;
    VisualElement image2;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        image=root.Q<VisualElement>("ImageLoad");

        image1=root.Q<VisualElement>("Starting");
        image2=root.Q<VisualElement>("Loading");
        image1.style.display=DisplayStyle.Flex;
        image2.style.display=DisplayStyle.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleImages();
        }
        image.style.rotate=new StyleRotate(new Rotate(new Angle(a)));
    }

    void ToggleImages()
    {
        image1.style.display=image1.style.display==DisplayStyle.Flex?DisplayStyle.None:DisplayStyle.Flex;
        image2.style.display=image2.style.display==DisplayStyle.Flex?DisplayStyle.None:DisplayStyle.Flex;
    }
}
