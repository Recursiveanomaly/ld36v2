using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuessPopup : MonoBehaviour 
{
    float m_showTime;
    float m_waitAfterShow = 0.2f;

    public InputField m_inputField;

    Pictograph m_currentPictograph;

    public void Setup(Pictograph pictograph)
    {
        m_inputField.text = "";
        m_showTime = Time.time;
        m_currentPictograph = pictograph;
    }

    public void FocusInputBox()
    {
        GamePanelManager.Instance.m_eventSystem.SetSelectedGameObject(m_inputField.gameObject, null);
        m_inputField.ActivateInputField();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > m_showTime + m_waitAfterShow && !GamePanelManager.Instance.DidUGUICaptureInput())
        {
            Close();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            GuessPictograph();
        }
    }

    public void GuessPictograph()
    {
        string guess = m_inputField.text;
        guess = guess.Trim();
        guess = guess.ToLower();
        if (m_currentPictograph.pictographName.Equals(Player.SanitizeString(guess)))
        {
            // celebrate!
            Player.Instance.SetIsKnown(m_currentPictograph.pictographName, true);
            Close();
        }
        else
        {
            // sadface
            m_inputField.text = "";
            FocusInputBox();
        }
    }

    public void Close()
    {
        TabletPanel.Instance.ResetToDefault();
    }
}
