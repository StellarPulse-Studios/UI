using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button setbut;
    public Button exitButton;

    VisualElement Menu;
    VisualElement setPage;
    VisualElement menuPage;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Menu = root.Q<VisualElement>("Menu");
        setPage = root.Q<VisualElement>("SettingsPages");
        menuPage = root.Q<VisualElement>("Menu");
        setbut = menuPage.Q<Button>("Settings");
        setbut.RegisterCallback<ClickEvent>(c =>
        {
            setPage.style.display = DisplayStyle.Flex;
            menuPage.style.display = DisplayStyle.None;
        });
        exitButton = menuPage.Q<Button>("ExitGame");
        exitButton.RegisterCallback<ClickEvent>(c =>
        {
            ExitPlayMode();
        });
    }

    public void setdisplay(bool isDisplaybool)
    {
        if (isDisplaybool == true)
        {
            Menu.style.display = DisplayStyle.Flex;
        }
        else
        {
            Menu.style.display = DisplayStyle.None;
        }
    }

    void ExitPlayMode()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit(); 
#endif
    }
}
