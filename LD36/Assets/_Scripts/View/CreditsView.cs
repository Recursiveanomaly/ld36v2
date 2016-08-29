using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CreditsView : MonoBehaviour
{
    bool m_creditsOpen = false;

    bool m_startingSet = false;
    float m_startingY;

    void Awake()
    {
        if (!m_startingSet)
        {
            m_startingSet = true;
            m_startingY = transform.position.y;
        }
        transform.position = new Vector3(transform.position.x, m_startingY + 850, transform.position.z);
    }

    public void ToggleCredits()
    {
        if (!m_startingSet)
        {
            m_startingSet = true;
            m_startingY = transform.position.y;
        }

        if (m_creditsOpen)
        {
            m_creditsOpen = false;
            transform.DOMoveY(m_startingY + 850, 0.75f);
        }
        else
        {
            m_creditsOpen = true;
            transform.DOMoveY(m_startingY, 0.75f).SetEase(Ease.OutQuint);
        }

        AudioManager.Instance.PlayPaper();
    }
}
