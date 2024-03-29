using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement Camera;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        Camera = root.Q<VisualElement>("CameraPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = Camera.Q<Button>("BackbtnS");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            Camera.style.display = DisplayStyle.None;
        };
    }
}

