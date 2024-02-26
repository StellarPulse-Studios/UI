using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : ScriptableObject
{
    private bool isInitialized;

    public struct pageTransition
    {

    }
    private void oninit()
    {

    }
    public void onEnter()
    {
        if (isInitialized == false)
        {
            oninit();

            isInitialized = true;
        }

    }
    public void onExit()
    {

    }
}
