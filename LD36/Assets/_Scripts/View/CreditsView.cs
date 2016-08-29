using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CreditsView : MonoBehaviour
{
    bool m_creditsOpen = false;

    public GameObject m_creditsIn;
    public GameObject m_creditsOut;

    void Awake()
    {
        transform.position = new Vector3(transform.position.x, m_creditsOut.transform.position.y, transform.position.z);
    }

    public void ToggleCredits()
    {
        if (m_creditsOpen)
        {
            m_creditsOpen = false;
            transform.DOMoveY(m_creditsOut.transform.position.y, 0.75f);
        }
        else
        {
            m_creditsOpen = true;
            transform.DOMoveY(m_creditsIn.transform.position.y, 0.75f).SetEase(Ease.OutQuint);
        }

        AudioManager.Instance.PlayPaper();
    }
}
