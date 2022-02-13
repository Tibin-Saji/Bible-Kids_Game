using UnityEngine;

public class AudioFade : MonoBehaviour
{
    AudioSource Audio;
    public float FadeInTime = 1f;
    public float FadeOutTime = 2f;
    public float MaxVol = 1f;
    bool FadeIn = false;
    bool FadeOut = true;

    IsOpen TransitionOver;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        CheckFadeIn();
        TransitionOver = FindObjectOfType<IsOpen>().GetComponent<IsOpen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeIn && TransitionOver.Opened)
        {
            if (Audio.volume < MaxVol)
            {
                Audio.volume += (Time.fixedDeltaTime / FadeInTime) * MaxVol;
            }
        }
        else
        {
            if (Audio.volume > 0)
            {
                Audio.volume -= Time.fixedDeltaTime / (FadeOutTime);
            }
        }
    }

    void CheckFadeIn()
    {
        FadeOut = false;
        FadeIn = true;
    }
    public void CheckFadeOut()
    {
        FadeOut = true;
        FadeIn = false;
    }
}
