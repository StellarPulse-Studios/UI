using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeContolPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement C;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        C = root.Q<VisualElement>("ChangeControlPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = C.Q<Button>("BackbtnSisth");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            C.style.display = DisplayStyle.None;
        };
    }
}
