using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement Au;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Au = root.Q<VisualElement>("AudioPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = Au.Q<Button>("BackbtnT");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            Au.style.display = DisplayStyle.None;
        };
    }
}

