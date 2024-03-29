using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AccessibilityPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement Assi;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Assi = root.Q<VisualElement>("AccessibilityPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = Assi.Q<Button>("BackbtnFour");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            Assi.style.display = DisplayStyle.None;
        };
    }
}
