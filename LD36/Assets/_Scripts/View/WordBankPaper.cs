using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;

public class WordBankPaper : MonoBehaviour 
{
    public GridLayoutGroup m_grid;
    public Text m_prefab;

    void Start()
    {
        Player.Instance.m_allWords.Sort();
        Player.Instance.m_allWords.Insert(0, "cheater");

        foreach (string word in Player.Instance.m_allWords)
        {
            Text newText = GameObject.Instantiate<Text>(m_prefab);
            newText.text = word;
            newText.transform.SetParent(m_grid.transform);
            newText.transform.localRotation = Quaternion.identity;

            if (newText.transform.childCount > 0)
            {
                Transform strike = newText.transform.GetChild(0);
                if (strike != null) strike.gameObject.SetActive(Player.Instance.IsKnown(word));
            }
        }
        Player.Instance.KnownPictographsChanged += new System.Action(Refresh);
    }

    void Refresh()
    {
        //Text[] children = transform.GetComponentsInChildren<Text>();
        //int i = 0;
        //foreach (string word in Player.Instance.m_allWords)
        //{
        //    if (i >= 0 && i < children.Length)
        //    {
        //        Text newText = children[i];
        //        newText.text = word;
        //        newText.transform.SetParent(m_grid.transform);
        //        newText.transform.localRotation = Quaternion.identity;

        //        if (newText.transform.childCount > 0)
        //        {
        //            Transform strike = newText.transform.GetChild(0);
        //            bool isKnown = Player.Instance.IsKnown(word);
        //            if (strike != null) strike.gameObject.SetActive(isKnown);
        //        }
        //    }
        //}

        //for(int i = m_grid.transform.childCount - 1; i >= 0; i--)
        //{
        //    Transform child = m_grid.transform.GetChild(i);
        //    child.SetParent(null);
        //    GameObject.Destroy(child);
        //}

        //foreach (string word in Player.Instance.m_allWords)
        //{
        //    Text newText = GameObject.Instantiate<Text>(m_prefab);
        //    newText.text = word;
        //    newText.transform.SetParent(m_grid.transform);
        //    newText.transform.localRotation = Quaternion.identity;

        //    if (newText.transform.childCount > 0)
        //    {
        //        Transform strike = newText.transform.GetChild(0);
        //        if (strike != null) strike.gameObject.SetActive(Player.Instance.IsKnown(word));
        //    }
        //}
        //Player.Instance.KnownPictographsChanged += new System.Action(Refresh);
    }
}
