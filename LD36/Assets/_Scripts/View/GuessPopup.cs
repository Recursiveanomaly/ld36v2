using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GuessPopup : MonoBehaviour 
{
    float m_showTime;
    float m_waitAfterShow = 0.2f;

    public InputField m_inputField;

    Pictograph m_currentPictograph;

    public GameObject m_helpRoot;
    float m_helpStartPositionX;
    bool m_helpStartSaved = false;

    public void Setup(Pictograph pictograph)
    {
        m_inputField.text = "";
        m_showTime = Time.time;
        m_currentPictograph = pictograph;
        ResetHelp();
    }

    public void FocusInputBox()
    {
        GamePanelManager.Instance.m_eventSystem.SetSelectedGameObject(m_inputField.gameObject, null);
        m_inputField.ActivateInputField();
    }

    public void ShowHelp()
    {
        if (!m_helpStartSaved)
        {
            m_helpStartSaved = true;
            m_helpStartPositionX = m_helpRoot.gameObject.transform.position.x;
        }

        m_helpRoot.transform.DOMoveX(m_helpStartPositionX + 400, 0.5f);
    }

    public void HideHelp()
    {
        if (!m_helpStartSaved)
        {
            m_helpStartSaved = true;
            m_helpStartPositionX = m_helpRoot.gameObject.transform.position.x;
        }

        m_helpRoot.transform.DOMoveX(m_helpStartPositionX, 0.5f);
    }

    public void ResetHelp()
    {
        if (!m_helpStartSaved)
        {
            m_helpStartSaved = true;
            m_helpStartPositionX = m_helpRoot.gameObject.transform.position.x;
        }

        m_helpRoot.gameObject.transform.position = new Vector3(m_helpStartPositionX, m_helpRoot.gameObject.transform.position.y, m_helpRoot.gameObject.transform.position.z);
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
