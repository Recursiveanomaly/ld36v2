using UnityEngine;
using System.Collections.Generic;

public class TabletFace : MonoBehaviour
{
    [TextArea(10, 100)]
    public string documentText;
    public string archeologistName;
    public string carbonDate;
    public string artifactName;

    int m_totalPictograms;
    int m_pictogramsSolved;

    void Start()
    {
        Pictograph[] pictoChildren = GetComponentsInChildren<Pictograph>();
        //List<string> words = new List<string>();
        //foreach (Pictograph child in pictoChildren)
        //{
        //    if (!words.Contains(child.pictographName))// && !Player.Instance.IsKnown(child.pictographName))
        //    {
        //        words.Add(child.pictographName);
        //    }
        //}

        m_totalPictograms = pictoChildren.Length;
    }

    public bool WordSolved()
    {
        m_pictogramsSolved++;

        if (m_pictogramsSolved >= m_totalPictograms)
        {
            //AudioManager.Instance.PlaySolvedTablet();
            return true;
        }

        return false;
    }
}
