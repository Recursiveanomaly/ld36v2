using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using DG.Tweening;

public class GamePanelManager : SingletonMonoBehaviour<GamePanelManager>
{
    public CityPanel m_cityPanel;
    public TabletPanel m_tabletPanel;

    public Canvas m_canvas;
    public EventSystem m_eventSystem;

    public Vector3 m_cameraLocCity_01;
    public Vector3 m_cameraLocCity_02;
    public Vector3 m_cameraLocCity_03;

    public List<CityTabletGroup> m_cityTabletGroups = new List<CityTabletGroup>();

    Vector3 m_cityPanelCameraLoc;

    protected override void Awake()
    {
        base.Awake();
        m_cityPanelCameraLoc = Camera.main.transform.position;
        if (m_cityPanel != null) m_cityPanel.gameObject.SetActive(true);
        if (m_tabletPanel != null) m_tabletPanel.gameObject.SetActive(false);
    }

    public bool DidUGUICaptureInput()
    {
        return GamePanelManager.Instance.m_eventSystem != null && GamePanelManager.Instance.m_eventSystem.currentSelectedGameObject != null;
    }

    public void ShowCityPanel()
    {
        // todo: animate

        //Camera.main.transform.position = m_cityPanelCameraLoc;
        Camera.main.transform.DOMove(m_cityPanelCameraLoc, 0.5f);

        if (m_cityPanel != null)
        {
            m_cityPanel.gameObject.SetActive(true);
            m_cityPanel.Peek();
        }
        if (m_tabletPanel != null)
        {
            m_tabletPanel.gameObject.SetActive(false);
        }
    }

    public void ShowTabletPanel(int city)
    {
        if (city < 0 || city >= m_cityTabletGroups.Count) return; // out of range

        // todo: animate

        switch (city)
        {
            default:
            case 0:
                TabletPanel.Instance.m_defaultCameraPosition = m_cameraLocCity_01;
                break;
            case 1:
                TabletPanel.Instance.m_defaultCameraPosition = m_cameraLocCity_02;
                break;
            case 2:
                TabletPanel.Instance.m_defaultCameraPosition = m_cameraLocCity_03;
                break;
        }

        TabletPanel.Instance.Setup(m_cityTabletGroups[city]);
        TabletPanel.Instance.ResetToDefault();

        m_cityTabletGroups[city].SetFirstTablet();

        if (m_cityPanel != null)
        {
            m_cityPanel.gameObject.SetActive(false);
        }
        if (m_tabletPanel != null)
        {
            m_tabletPanel.gameObject.SetActive(true);
            m_tabletPanel.m_infoPopup.Peek();
        }
    }
}
