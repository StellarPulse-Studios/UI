using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuPage : MonoBehaviour
{
    public UIDocument uidoc;

    public Button setbut;

    VisualElement Menu;
    VisualElement setPage;
    VisualElement menuPage;


    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Menu = root.Q<VisualElement>("Menu");


        setPage = root.Q<VisualElement>("SettingsPage");
        menuPage = root.Q<VisualElement>("Menu");
        setbut = menuPage.Q<Button>("Settings");
        setbut.RegisterCallback<ClickEvent>(c =>
        {
            setPage.style.display = DisplayStyle.Flex;
            menuPage.style.display = DisplayStyle.None;
        });

    }

    public void setdisplay(bool isDisplaybool)
    {
        if (isDisplaybool == true) { Menu.style.display = DisplayStyle.Flex; }

        else
        {
            Menu.style.display = DisplayStyle.None;
        }
    }
}
