using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Suvankar
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private UIDocument m_UIDocs;

        private int m_SelectedButtonIndex;
        private VisualElement[] m_Buttons;
        private Vector2 m_PrevMousePosiion;
        private VisualElement m_HoveredButton;

        private void Awake()
        {
            VisualElement root = m_UIDocs.rootVisualElement;

            VisualElement buttonsHolder = root.Q("ButtonsHolder");
            m_Buttons = new List<VisualElement>(buttonsHolder.Children()).ToArray();
        }

        private void OnEnable()
        {
            foreach (var button in m_Buttons)
            {
                button.RegisterCallback<MouseOverEvent>(OnMouseOverButton);
                button.RegisterCallback<MouseOutEvent>(OnMouseOutButton);
                button.RegisterCallback<ClickEvent>(OnButtonClicked);
            }
        }

        private void Start()
        {
            m_SelectedButtonIndex = 0;
            m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
            m_PrevMousePosiion = Input.mousePosition;
        }

        private void Update()
        {
            if ((Vector2)Input.mousePosition != m_PrevMousePosiion)
            {
                if (!UnityEngine.Cursor.visible && m_HoveredButton != null)
                {
                    for (int i = 0; i < m_Buttons.Length; i++)
                    {
                        if (m_Buttons[i] != m_HoveredButton)
                            continue;

                        m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
                        m_SelectedButtonIndex = i;
                        m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
                        break;
                    }
                }

                m_PrevMousePosiion = Input.mousePosition;
                UnityEngine.Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UnityEngine.Cursor.visible = false;

                int prevIndex = m_SelectedButtonIndex;
                m_SelectedButtonIndex = Mod(m_SelectedButtonIndex - 1, m_Buttons.Length);

                m_Buttons[prevIndex].ToggleInClassList("active");
                m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                UnityEngine.Cursor.visible = false;

                int prevIndex = m_SelectedButtonIndex;
                m_SelectedButtonIndex = Mod(m_SelectedButtonIndex + 1, m_Buttons.Length);

                m_Buttons[prevIndex].ToggleInClassList("active");
                m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
            }
        }

        private void OnDisable()
        {
            foreach (var button in m_Buttons)
            {
                button.UnregisterCallback<MouseOverEvent>(OnMouseOverButton);
                button.UnregisterCallback<MouseOutEvent>(OnMouseOutButton);
                button.UnregisterCallback<ClickEvent>(OnButtonClicked);
            }
        }

        private void OnMouseOverButton(MouseOverEvent mouseOverEvent)
        {
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                VisualElement button = m_Buttons[i];

                if (mouseOverEvent.currentTarget != button)
                    continue;

                m_HoveredButton = button;

                m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
                m_SelectedButtonIndex = i;
                m_Buttons[m_SelectedButtonIndex].ToggleInClassList("active");
                break;
            }
        }

        private void OnMouseOutButton(MouseOutEvent mouseOutEvent)
        {
            m_HoveredButton = null;
        }

        private void OnButtonClicked(ClickEvent clickEvent)
        {
            foreach (var button in m_Buttons)
            {
                if (clickEvent.currentTarget != button)
                    continue;

                print($"You have clicked on {button.name}");
                break;
            }
        }

        private int Mod(int divident, int divisor)
        {
            if (divident < 0)
                divident = divisor + divident;
            return divident % divisor;
        }
    }
}
