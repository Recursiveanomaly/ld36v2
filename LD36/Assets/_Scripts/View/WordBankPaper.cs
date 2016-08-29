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
                if (strike != null)
                {
                    strike.gameObject.SetActive(Player.Instance.IsKnown(word));
                    WordBankStrikeView strikeWord = strike.gameObject.GetComponent<WordBankStrikeView>();
                    if (strikeWord != null)
                    {
                        strikeWord.m_myWord = word;
                        Player.Instance.KnownPictographsStringChanged += new System.Action<string, bool>(strikeWord.WordChanged);
                    }
                }
            }
        }
    }
}
