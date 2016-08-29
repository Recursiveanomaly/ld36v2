using UnityEngine;
using System.Collections;
using System;

public class WordBankStrikeView : MonoBehaviour 
{
    [NonSerialized]
    public string m_myWord;

    public void WordChanged(string word, bool isKnown)
    {
        if (word.Equals(m_myWord))
        {
            gameObject.SetActive(isKnown);
        }
    }
}
