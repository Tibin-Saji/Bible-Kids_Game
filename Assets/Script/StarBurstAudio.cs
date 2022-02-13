using UnityEngine;
using System.Collections;

public class StarBurstAudio : MonoBehaviour
{
    public AudioClip VictoryClip;
    AudioSource m_AudioSource;
    bool hasPlayed = false;
    ParticleSystem StarBurst;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = FindObjectOfType<AudioSource>();
        StarBurst = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StarBurst.isPlaying && !hasPlayed)
        {
            hasPlayed = true;
            StartCoroutine(WaitAndPlayParticle());
        }
        if (StarBurst.isStopped)
        {
            hasPlayed = false;
        }
    }

    IEnumerator WaitAndPlayParticle()
    {
        yield return new WaitForSeconds(StarBurst.main.startDelay.constant);

        m_AudioSource.PlayOneShot(VictoryClip, 10f);
    }
}
