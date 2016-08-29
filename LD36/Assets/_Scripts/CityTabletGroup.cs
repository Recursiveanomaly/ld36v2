using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class CityTabletGroup : MonoBehaviour
{
    public Vector3 m_activeTabletPosition;
    public Vector3 m_activeTabletRotation;

    public List<TabletRoot> tabletList = new List<TabletRoot>();
    int m_currentTabletIndex;

    public void SetFirstTablet()
    {
        foreach (TabletRoot tablet in tabletList)
        {
            tablet.ReturnToShelf();
        }
        m_currentTabletIndex = 0;
        tabletList[m_currentTabletIndex].Unshelf(m_activeTabletPosition, Quaternion.Euler(m_activeTabletRotation));
    }

    public void NextTablet()
    {
        tabletList[m_currentTabletIndex].ReturnToShelf();

        m_currentTabletIndex++;
        if (m_currentTabletIndex >= tabletList.Count) m_currentTabletIndex = 0;

        tabletList[m_currentTabletIndex].Unshelf(m_activeTabletPosition, Quaternion.Euler(m_activeTabletRotation));
    }

    public void PreviousTablet()
    {
        tabletList[m_currentTabletIndex].ReturnToShelf();

        m_currentTabletIndex--;
        if (m_currentTabletIndex < 0) m_currentTabletIndex = tabletList.Count - 1;

        tabletList[m_currentTabletIndex].Unshelf(m_activeTabletPosition, Quaternion.Euler(m_activeTabletRotation));
    }

    public TabletFace GetCurrentTabletFace()
    {
        if (tabletList == null || m_currentTabletIndex < 0 || m_currentTabletIndex >= tabletList.Count) return null;

        TabletFace face = tabletList[m_currentTabletIndex].GetComponentInChildren<TabletFace>();
        return face;
    }
}
