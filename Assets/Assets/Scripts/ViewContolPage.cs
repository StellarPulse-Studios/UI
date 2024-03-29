using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ViewContolPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement V;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        V = root.Q<VisualElement>("ViewControlPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = V.Q<Button>("BackbtnFifth");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            V.style.display = DisplayStyle.None;
        };
    }
}

