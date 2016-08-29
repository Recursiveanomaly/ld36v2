using UnityEngine;
using System.Collections;

public class CityButtonView : MonoBehaviour 
{
    public GameObject m_tabletsRoot;
    public int m_cityIndex;

    public UnlockText m_unlockText;

    public void OnClick()
    {
        if (m_unlockText == null || !m_unlockText.IsLocked())
        {
            GamePanelManager.Instance.ShowTabletPanel(m_cityIndex);
        }
    }
}
