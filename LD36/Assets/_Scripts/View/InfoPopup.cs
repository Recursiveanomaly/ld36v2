using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class InfoPopup : MonoBehaviour
{
    public Text m_artifactName;
    public Text m_archaeologist;
    public Text m_carbonDate;
    public Text m_description;

    float m_showTime;
    float m_waitAfterShow = 0.2f;

    public GameObject m_nonTweenGUI;
    public GameObject m_tweenGUI;

    void Awake()
    {
        //m_tweenGUI.transform.position = new Vector3(m_startingX + 600, m_tweenGUI.transform.position.y, m_tweenGUI.transform.position.z);
    }

    bool m_isHidden = true;
    bool m_startingXSet = false;
    float m_startingX;


    public void ResetPeek()
    {
        if (!m_startingXSet)
        {
            m_startingX = m_tweenGUI.transform.position.x;
            m_startingXSet = true;
        }
        m_tweenGUI.transform.DOMoveX(m_startingX, 0f);
    }

    public void Peek(float time = 0.5f)
    {
        if (!m_startingXSet)
        {
            m_startingX = m_tweenGUI.transform.position.x;
            m_startingXSet = true;
        }
        m_nonTweenGUI.gameObject.SetActive(false);
        m_isHidden = true;
        m_tweenGUI.transform.DOMoveX(m_startingX - 65, time);
    }

    public void Show()
    {
        if (!m_startingXSet)
        {
            m_startingX = m_tweenGUI.transform.position.x;
            m_startingXSet = true;
        }
        gameObject.SetActive(true);
        m_nonTweenGUI.gameObject.SetActive(true);
        m_isHidden = false;
        m_tweenGUI.transform.DOMoveX(m_startingX - 665, 0.5f);
    }

    public void Setup(TabletFace tablet)
    {
        m_showTime = Time.time;

        if (tablet != null)
        {
            m_artifactName.text = tablet.artifactName;
            m_archaeologist.text = tablet.archeologistName;
            m_carbonDate.text = tablet.carbonDate;
            m_description.text = tablet.documentText;
        }
        else
        {
            m_artifactName.text = "";
            m_archaeologist.text = "";
            m_carbonDate.text = "";
            m_description.text = "";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > m_showTime + m_waitAfterShow && !GamePanelManager.Instance.DidUGUICaptureInput())
        {
            Close();
        }
    }

    public void Close()
    {
        TabletPanel.Instance.ResetToDefault();
    }
}
