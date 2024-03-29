using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayPage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button backButton;

    VisualElement GamePlay;
    VisualElement SettingsPages;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        GamePlay = root.Q<VisualElement>("GamePlayPage");
        SettingsPages = root.Q<VisualElement>("SettingsPages");

        backButton = GamePlay.Q<Button>("BackbtnF");

        backButton.clicked += () =>
        {
            SettingsPages.style.display = DisplayStyle.Flex;
            GamePlay.style.display = DisplayStyle.None;
        };
    }
}
