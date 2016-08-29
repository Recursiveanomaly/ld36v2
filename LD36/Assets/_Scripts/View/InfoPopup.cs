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
    public GameObject m_infoIn;
    public GameObject m_infoOut;

    public void ResetPeek()
    {
        gameObject.SetActive(false);
        m_tweenGUI.transform.DOMoveX(m_infoOut.transform.position.x + 100, 0f);
    }

    public void Peek(float time = 0.5f)
    {
        gameObject.SetActive(false);
        m_isHidden = true;
        m_tweenGUI.transform.DOMoveX(m_infoOut.transform.position.x, time);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        m_isHidden = false;
        m_tweenGUI.transform.DOMoveX(m_infoIn.transform.position.x, 0.5f);
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

        AudioManager.Instance.PlayPaper();
    }
}
