using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingPage : MonoBehaviour
{
    public UIDocument uidoc;

    VisualElement Load;
    public float fakeLoadTime=6;
    public MenuPage menuPage;
    bool isbulbul;
    void Start()
    {       
        VisualElement root = uidoc.rootVisualElement;
        Load = root.Q<VisualElement>("Loading");
       
    }

    public void setdisplay(bool isDisplaybool)
    {
        if(isDisplaybool==true) { Load.style.display = DisplayStyle.Flex; }

        else
        {
            Load.style.display = DisplayStyle.None;
        }

        isbulbul = true;
    }

    void Update()
    {
        if (isbulbul == true)
        {
            if (fakeLoadTime <= 0)
            {
                Load.style.display = DisplayStyle.None;
                print("Joy Mohunbagan");
                menuPage.setdisplay(true);
                enabled = false;

            }
            fakeLoadTime -= Time.deltaTime;
        }
    }

}
