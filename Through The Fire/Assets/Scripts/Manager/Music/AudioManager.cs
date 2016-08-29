using UnityEngine;
using System.Collections;

public class AudioManager : Singleton<AudioManager> 
{
    [SerializeField]AudioSource m_audio;

    void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
    }

    public void chargeAudioBackGround(AudioClip _audio)
    {
        if (!m_audio)
            m_audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        m_audio.clip = _audio;
        m_audio.Play();
    }

    public void audioOnShot(AudioClip _audio)
    {
        if (!m_audio)
            m_audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        m_audio.PlayOneShot(_audio);
    }
}
