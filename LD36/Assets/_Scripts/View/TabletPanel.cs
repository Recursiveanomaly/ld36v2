using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

public class TabletPanel : SingletonMonoBehaviour<TabletPanel> 
{
    public enum eTabletViewState
    {
        kDefault,
        kGuessPopup,
        kInfoPopup
    }

    [NonSerialized]
    public eTabletViewState m_currentState;

    public GuessPopup m_guessPopup;
    public InfoPopup m_infoPopup;

    public GameObject m_defaultGUI;

    public Vector3 m_guessPictographCameraOffset;

    [NonSerialized]
    public Vector3 m_defaultCameraPosition;
    Vector3 m_cameraFocus;

    CityTabletGroup m_cityTabletGroup;

    protected override void Awake()
    {
        base.Awake();
        ResetToDefault();
    }

    public void Setup(CityTabletGroup cityTabletGroup)
    {
        m_cityTabletGroup = cityTabletGroup;
        m_infoPopup.ResetPeek();
    }

    public void ResetToDefault()
    {
        if (m_guessPopup != null) m_guessPopup.gameObject.SetActive(false);
        if (m_infoPopup != null) m_infoPopup.Peek();

        if (m_defaultGUI != null) m_defaultGUI.gameObject.SetActive(true);

        DOTween.defaultEaseType = Ease.InOutQuad;
        Camera.main.transform.DOMove(m_defaultCameraPosition, 0.5f);
        //Camera.main.transform.position = m_defaultCameraPosition;

        m_currentState = eTabletViewState.kDefault;
    }

    public void ShowGuessPopup(Pictograph pictograph)
    {
        if (m_currentState != eTabletViewState.kDefault || pictograph == null || m_guessPopup == null) return;

        if (m_infoPopup != null) m_infoPopup.Peek();
        if (m_defaultGUI != null) m_defaultGUI.gameObject.SetActive(false);

        //Camera.main.transform.position = pictograph.transform.position + m_guessPictographCameraOffset;
        Camera.main.transform.DOMove(pictograph.transform.position + m_guessPictographCameraOffset, 0.25f);

        m_guessPopup.Setup(pictograph);
        m_guessPopup.gameObject.SetActive(true);
        m_guessPopup.FocusInputBox();
        m_currentState = eTabletViewState.kInfoPopup;

        AudioManager.Instance.PlayUIClick();
    }

    public void ShowInfoPopup()
    {
        if (m_currentState != eTabletViewState.kDefault || m_cityTabletGroup == null || m_infoPopup == null) return;

        if (m_guessPopup != null) m_guessPopup.gameObject.SetActive(false);
        if (m_defaultGUI != null) m_defaultGUI.gameObject.SetActive(false);

        m_infoPopup.Show();
        m_infoPopup.Setup(m_cityTabletGroup.GetCurrentTabletFace());
        m_currentState = eTabletViewState.kInfoPopup;

        AudioManager.Instance.PlayPaper();
    }

    public void NextTabletPressed()
    {
        if (m_cityTabletGroup != null) m_cityTabletGroup.NextTablet();
        AudioManager.Instance.SwitchTablet();
    }

    public void PreviousTabletPressed()
    {
        if (m_cityTabletGroup != null) m_cityTabletGroup.PreviousTablet();
        AudioManager.Instance.SwitchTablet();
    }
}
