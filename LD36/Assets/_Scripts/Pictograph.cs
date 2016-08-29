using UnityEngine;
using System.Collections;
using System;

public class Pictograph : MonoBehaviour
{
    public string pictographName;
    public TextMesh answer;

    public TabletFace m_parentFace;

    void Start()
    {
        m_parentFace = GetComponentInParent<TabletFace>();
        CheckIfKnown();
        Player.Instance.KnownPictographsChanged += new Action(CheckIfKnown);
    }

    public void CheckIfKnown()
    {
        if (Player.Instance.IsKnown(pictographName))
        {
            if (answer != null)
            {
                answer.text = pictographName.ToUpper();
                answer.gameObject.SetActive(true);

                if (m_parentFace != null) m_parentFace.WordSolved();
            }
        }
        else
        {
            if (answer != null)
            {
                answer.gameObject.SetActive(false);
            }
        }
    }

    void OnMouseDown()
    {
        //Player.Instance.SetIsKnown(pictographName, !Player.Instance.IsKnown(pictographName));

        if (!Player.Instance.IsKnown(pictographName))
        {
            TabletPanel.Instance.ShowGuessPopup(this);
        }
    }
}
