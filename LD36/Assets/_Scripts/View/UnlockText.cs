using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UnlockText : MonoBehaviour 
{
    public int m_requiredNumber;
    public Text m_text;

	void Start () 
    {
        UpdateText();
        Player.Instance.KnownPictographsChanged += new Action(UpdateText);
	}

    void UpdateText()
    {
        int numberUnlocked = Player.Instance.UnlockCount();
        if (m_requiredNumber - numberUnlocked > 0)
        {
            m_text.text = string.Format("Translate {0} more Pictographs to unlock", m_requiredNumber - numberUnlocked);
        }
        else
        {
            m_text.text = "";
        }
    }

    public bool IsLocked()
    {
        int numberUnlocked = Player.Instance.UnlockCount();
        return m_requiredNumber - numberUnlocked > 0;
    }
}
