using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayPage : MonoBehaviour
{
    public UIDocument uidoc;
    private Button backButton;
    private VisualElement settingsPage;

    // Reference to the UI manager that handles transitions
    public UIManager uiManager;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        backButton = root.Q<Button>("BackbtnF");
        if (backButton != null)
        {
            backButton.clicked += OnBackButtonClick;
        }
        else
        {
            Debug.LogError("Back button not found!");
        }

        // Find the SettingsPages element by traversing up the hierarchy
        settingsPage = root.Q<VisualElement>("SettingsPages");
        if (settingsPage == null)
        {
            Debug.LogError("SettingsPages not found!");
        }
    }

    void OnBackButtonClick()
    {
        Debug.Log("Back button clicked!");

        // Call a method in the UIManager to show the settings page
        uiManager.ShowSettingsPage();
    }
}

public class UIManager : MonoBehaviour
{
    public void ShowSettingsPage()
    {
        // Get a reference to GamePlayPage
        GamePlayPage gamePlayPage = FindObjectOfType<GamePlayPage>();
        if (gamePlayPage != null && gamePlayPage.settingsPage != null)
        {
            gamePlayPage.settingsPage.style.display = DisplayStyle.Flex;
        }
        else
        {
            Debug.LogError("GamePlayPage or SettingsPages not found!");
        }
    }
}
