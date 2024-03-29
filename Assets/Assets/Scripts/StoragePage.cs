using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoragePage : MonoBehaviour
{
    public UIDocument uidoc;
    public Button weaponsButton;
    public Button armourButton;
    public Button skillButton;
    public Button mapButton;
    public Button goalButton;
    public Button resourceButton;

    VisualElement storage;
    VisualElement weaponsPage;
    VisualElement armourPage;
    VisualElement skillPage;
    VisualElement mapPage;
    VisualElement goalPage;
    VisualElement resourcePage;

    VisualElement nav;

    void Start()
    {
        VisualElement root = uidoc.rootVisualElement;

        storage = root.Q<VisualElement>("Storage");

        // Weapons
        weaponsPage = root.Q<VisualElement>("Weaponspage");
        weaponsButton = storage.Q<Button>("Weapons");
        SetupButtonClick(weaponsButton, weaponsPage);

        // Armour
        armourPage = root.Q<VisualElement>("Armourpage");
        armourButton = storage.Q<Button>("Armour");
        SetupButtonClick(armourButton, armourPage);

        // Skills
        skillPage = root.Q<VisualElement>("Skillspage");
        skillButton = storage.Q<Button>("Skills");
        SetupButtonClick(skillButton, skillPage);

        // Maps
        mapPage = root.Q<VisualElement>("Mappage");
        mapButton = storage.Q<Button>("Map");
        SetupButtonClick(mapButton, mapPage);

        // Goals
        goalPage = root.Q<VisualElement>("Goalspage");
        goalButton = storage.Q<Button>("Goals");
        SetupButtonClick(goalButton, goalPage);

        // Resources
        resourcePage = root.Q<VisualElement>("Resourcepage");
        resourceButton = storage.Q<Button>("Resource");
        SetupButtonClick(resourceButton, resourcePage);
    }

    void SetupButtonClick(Button button, VisualElement setPage)
    {
        button.RegisterCallback<ClickEvent>(c=>{
            weaponsPage.style.display = DisplayStyle.None;
            armourPage.style.display = DisplayStyle.None;
            skillPage.style.display = DisplayStyle.None;
            mapPage.style.display = DisplayStyle.None;
            goalPage.style.display = DisplayStyle.None;
            resourcePage.style.display = DisplayStyle.None;

            setPage.style.display = DisplayStyle.Flex;
        });
    }
}
