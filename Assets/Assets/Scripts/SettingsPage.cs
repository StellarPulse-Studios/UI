using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsPage : MonoBehaviour
{
    public UIDocument uidoc;

    VisualElement setting;
    public Button setbut;
    public Button backButton; 

    VisualElement gameplayPage;
    VisualElement cameraPage;
    VisualElement audioPage;
    VisualElement accessibilityPage;
    VisualElement viewControlPage;
    VisualElement changeControlPage;
    VisualElement creditsPage;

    VisualElement menuPage; 

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;
        setting = root.Q<VisualElement>("SettingsPages");

        gameplayPage = root.Q<VisualElement>("GamePlayPage");
        cameraPage = root.Q<VisualElement>("CameraPage");
        audioPage = root.Q<VisualElement>("AudioPage");
        accessibilityPage = root.Q<VisualElement>("AccessibilityPage");
        viewControlPage = root.Q<VisualElement>("ViewControlPage");
        changeControlPage = root.Q<VisualElement>("ChangeControlPage");
        creditsPage = root.Q<VisualElement>("CreditsPage");

        menuPage = root.Q<VisualElement>("Menu");
        backButton = setting.Q<Button>("Back");
        backButton.RegisterCallback<ClickEvent>(c =>
        {
            menuPage.style.display = DisplayStyle.Flex;
            setting.style.display = DisplayStyle.None;
        });

        setbut = setting.Q<Button>("Gameplay");
        setbut.RegisterCallback<ClickEvent>(c =>
        {
            ShowPageAndHideOthers(gameplayPage);
        });
        RegisterButton(setting.Q<Button>("Camera"), cameraPage);
        RegisterButton(setting.Q<Button>("Audio"), audioPage);
        RegisterButton(setting.Q<Button>("Accessibility"), accessibilityPage);
        RegisterButton(setting.Q<Button>("ViewControl"), viewControlPage);
        RegisterButton(setting.Q<Button>("ChangeControl"), changeControlPage);
        RegisterButton(setting.Q<Button>("Credits"), creditsPage);
    }

    void RegisterButton(Button button, VisualElement page)
    {
        button.RegisterCallback<ClickEvent>(c =>
        {
            ShowPageAndHideOthers(page);
        });
    }

    void ShowPageAndHideOthers(VisualElement pageToShow)
    {
        gameplayPage.style.display = DisplayStyle.None;
        cameraPage.style.display = DisplayStyle.None;
        audioPage.style.display = DisplayStyle.None;
        accessibilityPage.style.display = DisplayStyle.None;
        viewControlPage.style.display = DisplayStyle.None;
        changeControlPage.style.display = DisplayStyle.None;
        creditsPage.style.display = DisplayStyle.None;

        pageToShow.style.display = DisplayStyle.Flex;
        setting.style.display = DisplayStyle.None;
    }

    public void SetDisplay(bool isDisplaybool)
    {
        if (isDisplaybool)
        {
            setting.style.display = DisplayStyle.Flex;
        }
        else
        {
            setting.style.display = DisplayStyle.None;
        }
    }
}
