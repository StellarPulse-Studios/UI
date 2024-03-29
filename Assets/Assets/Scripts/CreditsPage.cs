using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreditsPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement Cr;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Cr = root.Q<VisualElement>("CreditsPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = Cr.Q<Button>("BackbtnSeventh");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            Cr.style.display = DisplayStyle.None;
        };
    }
}
