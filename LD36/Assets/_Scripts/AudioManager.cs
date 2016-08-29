using UnityEngine;
using System.Collections;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public AudioSource m_audioSource;

    public AudioClip UIclick;
    public AudioClip guessedWrong;
    public AudioClip paper;
    public AudioClip solvedCity;
    public AudioClip solvedTablet;
    public AudioClip solvedWord;
    public AudioClip switchBetween;
    public AudioClip switchTablet;
    
    public void PlayUIClick()
    {
        m_audioSource.clip = UIclick;
        m_audioSource.Play();
    }

    public void PlayGuessedWrong()
    {
        m_audioSource.clip = guessedWrong;
        m_audioSource.Play();
    }

    public void PlayPaper()
    {
        m_audioSource.clip = paper;
        m_audioSource.Play();
    }

    public void PlaySolvedCity()
    {
        m_audioSource.clip = solvedCity;
        m_audioSource.Play();
    }

    public void PlaySolvedTablet()
    {
        m_audioSource.clip = solvedTablet;
        m_audioSource.Play();
    }

    public void PlaySolvedWord()
    {
        m_audioSource.clip = solvedWord;
        m_audioSource.Play();
    }

    public void SwitchBetween()
    {
        m_audioSource.clip = switchBetween;
        m_audioSource.Play();
    }

    public void SwitchTablet()
    {
        m_audioSource.clip = switchTablet;
        m_audioSource.Play();
    }
}
