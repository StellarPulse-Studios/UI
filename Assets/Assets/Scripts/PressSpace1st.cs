using UnityEngine;
using UnityEngine.UIElements;

public class PressSpace1st : MonoBehaviour
{
    public UIDocument uidoc;
    public float a = 0;
    public bool displayStarting = true;
    public UIState startingState;
    public Button setbut;

    VisualElement image;
    VisualElement image1;
    VisualElement image2;
    VisualElement setPage;
    VisualElement menuPage;
   
    void Start()
    {
       
        VisualElement root = uidoc.rootVisualElement;
        image = root.Q<VisualElement>("ImageLoad");
        image1 = root.Q<VisualElement>("Starting");
        image2 = root.Q<VisualElement>("Loading");
        setPage = root.Q<VisualElement>("SettingsPage");
        menuPage = root.Q<VisualElement>("Menu");
        setbut = menuPage.Q<Button>("Settings");
        setbut.RegisterCallback<ClickEvent>(c =>
        {
            setPage.style.display = DisplayStyle.Flex;
            menuPage.style.display = DisplayStyle.None;
        });

        image1.style.display = displayStarting ? DisplayStyle.Flex : DisplayStyle.None;
        image2.style.display = displayStarting ? DisplayStyle.None : DisplayStyle.Flex;
        startingState.onEnter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleImages();
        }
        image.style.rotate = new StyleRotate(new Rotate(new Angle(a)));
    }

    void ToggleImages()
    {
        displayStarting = !displayStarting;
        image1.style.display = displayStarting ? DisplayStyle.Flex : DisplayStyle.None;
        image2.style.display = displayStarting ? DisplayStyle.None : DisplayStyle.Flex;
    }

}
