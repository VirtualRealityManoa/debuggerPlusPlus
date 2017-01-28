using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class GameMusicControl : MonoBehaviour {

    public GameObject startingRoach;
    public AudioMixerSnapshot menu;
    public AudioMixerSnapshot start;
    public AudioSource theStart;
    //public AudioClip[] stings;
    //public AudioSource stingSource;
    public float bpm = 200;             //optional

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;
    private bool hasPlayedAlready;

    // Use this for initialization
    void Start () 
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 4;

        menu.TransitionTo(m_TransitionIn);

        theStart = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
       if(startingRoach.activeSelf == false)
       {
            start.TransitionTo(m_TransitionOut);

            if (hasPlayedAlready == false)
            {
                theStart.Play();
                hasPlayedAlready = true;
            }
       }
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            menu.TransitionTo(m_TransitionIn);
            PlaySting();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            start.TransitionTo(m_TransitionOut);
        }
    }

    void PlaySting()
    {
        int randClip = Random.Range(0, stings.Length);
        stingSource.clip = stings[randClip];
        stingSource.Play();
    }
    */
}
