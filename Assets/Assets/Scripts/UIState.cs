using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="newUiState",menuName ="Ui/Page")]
public class UIState : ScriptableObject
{
    public string PageName;
    public void onEnter()
    {
       
    }
    public void onExit() { 
    
    }
}
