using UnityEngine;
using System.Collections;

public class CityButtonView : MonoBehaviour 
{
    public GameObject m_tabletsRoot;
    public int m_cityIndex;

    public void OnClick()
    {
        GamePanelManager.Instance.ShowTabletPanel(m_cityIndex);
    }
}
