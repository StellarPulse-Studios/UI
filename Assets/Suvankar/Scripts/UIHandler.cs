using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Suvankar
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private UIDocument m_UIDocs;
        [SerializeField] private float m_TotalTime = 1.0f;
        [SerializeField] private bool m_IsAnimationCompleted;

        private int m_SelectedButtonIndex;
        private VisualElement m_ButtonsHolder;
        private VisualElement[] m_Buttons;
        private VisualElement m_HoveredButton;
        private Vector2 m_PrevMousePosiion;

        private float m_ElapsedTime;

        private const string c_ActiveClassName = "active";
        private const string c_HideClassName = "hide";

        private void Awake()
        {
            VisualElement root = m_UIDocs.rootVisualElement;
            m_ButtonsHolder = root.Q("ButtonsHolder");
        }

        private void OnEnable()
        {
            m_ButtonsHolder.RegisterCallback<GeometryChangedEvent>(OnChildrenCountChanged);

            foreach (var button in m_ButtonsHolder.Children())
            {
                button.RegisterCallback<MouseOverEvent>(OnMouseOverButton);
                button.RegisterCallback<MouseOutEvent>(OnMouseOutButton);
                button.RegisterCallback<ClickEvent>(OnButtonClicked);
            }
        }

        private void Start()
        {
            m_PrevMousePosiion = Input.mousePosition;
            m_SelectedButtonIndex = 0;
            InitButtons();
        }

        private void Update()
        {
            HandleMouseInteraction();
            HandleKeyboardInteraction();

            if (Input.GetKey(KeyCode.Space) && !m_IsAnimationCompleted)
            {
                m_ElapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(m_ElapsedTime / m_TotalTime);
                float position = Mathf.LerpUnclamped(-480.0f, -780.0f, t);

                var root = m_UIDocs.rootVisualElement;
                var titleScreen = root.Q("TitleScreen");
                titleScreen.Q("LeftArrow").style.left = new StyleLength(position);
                titleScreen.Q("RightArrow").style.right = new StyleLength(position);

                if (m_ElapsedTime >= m_TotalTime)
                {
                    m_IsAnimationCompleted = true;
                    OnAnimationCompleted();
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && !m_IsAnimationCompleted)
            {
                m_ElapsedTime = 0.0f;

                var root = m_UIDocs.rootVisualElement;
                var titleScreen = root.Q("TitleScreen");
                titleScreen.Q("LeftArrow").style.left = new StyleLength(-480.0f);
                titleScreen.Q("RightArrow").style.right = new StyleLength(-480.0f);
            }
        }

        private void OnAnimationCompleted()
        {
            var root = m_UIDocs.rootVisualElement;
            var background = root.Q("Background");
            var titleScreen = root.Q("TitleScreen");
            var mainMenuScreen = root.Q("MainMenuScreen");

            titleScreen.RegisterCallback<TransitionEndEvent>(e =>
            {
                titleScreen.AddToClassList("hide");
            });

            if (!background.ClassListContains("zoomInBackground"))
            {
                background.AddToClassList("zoomInBackground");
            }

            if (!titleScreen.ClassListContains("opacity-0"))
            {
                titleScreen.AddToClassList("opacity-0");
            }

            if (mainMenuScreen.ClassListContains("hide"))
            {
                mainMenuScreen.RemoveFromClassList("opacity-0");
                mainMenuScreen.RemoveFromClassList("hide");
            }
        }

        private void OnDisable()
        {
            m_ButtonsHolder.UnregisterCallback<GeometryChangedEvent>(OnChildrenCountChanged);

            foreach (var button in m_ButtonsHolder.Children())
            {
                button.UnregisterCallback<MouseOverEvent>(OnMouseOverButton);
                button.UnregisterCallback<MouseOutEvent>(OnMouseOutButton);
                button.UnregisterCallback<ClickEvent>(OnButtonClicked);
            }
        }

        private void InitButtons()
        {
            VisualElement selectedButton = (m_Buttons == null || m_Buttons.Length == 0) ? null : m_Buttons[m_SelectedButtonIndex];
            List<VisualElement> buttons = new List<VisualElement>();

            foreach (var button in m_ButtonsHolder.Children())
            {
                button.RemoveFromClassList(c_ActiveClassName);

                if (button.ClassListContains(c_HideClassName))
                    continue;

                if (button == selectedButton)
                    m_SelectedButtonIndex = buttons.Count;

                buttons.Add(button);
            }

            m_Buttons = buttons.ToArray();
            m_SelectedButtonIndex = Mathf.Clamp(m_SelectedButtonIndex, 0, m_Buttons.Length - 1);
            m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
        }

        private void HandleMouseInteraction()
        {
            if ((Vector2)Input.mousePosition == m_PrevMousePosiion)
                return;

            m_PrevMousePosiion = Input.mousePosition;
            bool isCursorVisiblePreviously = UnityEngine.Cursor.visible;
            UnityEngine.Cursor.visible = true;

            if (isCursorVisiblePreviously || m_HoveredButton == null)
                return;

            for (int i = 0; i < m_Buttons.Length; i++)
            {
                if (m_Buttons[i] != m_HoveredButton)
                    continue;

                m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
                m_SelectedButtonIndex = i;
                m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
                break;
            }
        }

        private void HandleKeyboardInteraction()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectButton(m_SelectedButtonIndex - 1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectButton(m_SelectedButtonIndex + 1);
            }
        }

        private void SelectButton(int newSelectedButtonIndex)
        {
            UnityEngine.Cursor.visible = false;

            int prevIndex = m_SelectedButtonIndex;
            m_SelectedButtonIndex = Mod(newSelectedButtonIndex, m_Buttons.Length);

            m_Buttons[prevIndex].ToggleInClassList(c_ActiveClassName);
            m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
        }

        private void OnMouseOverButton(MouseOverEvent mouseOverEvent)
        {
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                VisualElement button = m_Buttons[i];

                if (mouseOverEvent.currentTarget != button)
                    continue;

                m_HoveredButton = button;

                m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
                m_SelectedButtonIndex = i;
                m_Buttons[m_SelectedButtonIndex].ToggleInClassList(c_ActiveClassName);
                break;
            }
        }

        private void OnMouseOutButton(MouseOutEvent mouseOutEvent)
        {
            m_HoveredButton = null;
        }

        private void OnChildrenCountChanged(GeometryChangedEvent geometryChangedEvent)
        {
            InitButtons();
        }

        private void OnButtonClicked(ClickEvent clickEvent)
        {
            foreach (var button in m_Buttons)
            {
                if (clickEvent.currentTarget != button)
                    continue;

                OnClicked(button);
                break;
            }
        }

        private int Mod(int divident, int divisor)
        {
            if (divident < 0)
                divident = divisor + divident;
            return divident % divisor;
        }

        private void OnClicked(VisualElement button)
        {

        }    
    }
}
