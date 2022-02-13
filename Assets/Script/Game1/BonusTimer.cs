using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour
{
    public Text DigitalText;
    IsOpen TimerTrigger;
    float BonusTime = 30f;
    public float TimeLeft;
    float LowTime = 10f;
    public bool runTimer;

    public Animator ClockAnim;
    bool isInAnimation;

    void Start()
    {
        TimerTrigger = FindObjectOfType<IsOpen>();
        TimeLeft = BonusTime;
    }
    void Update()
    {
        if (TimerTrigger.Opened)
        {
            if (runTimer)
            {
                TimeLeft -= Time.deltaTime;
                TimeEffects();
                DigitalText.text ="00 : " + string.Format("{0:00}", Mathf.Clamp(TimeLeft, 0f, BonusTime));
            }
            else
            {
                ResetTime();
            }
        } 
    }

    void TimeEffects()
    {
        if(TimeLeft < LowTime + 1)          // from playtest found that this gives red on time
        {
            DigitalText.color = Color.red;
        }
        else
        {
            DigitalText.color = Color.black;
        }

        if(TimeLeft <= 0f && !isInAnimation)
        {
            ClockAnim.Play("BonusTimerClock");
            isInAnimation = true;
        }
        else if (isInAnimation)
        {
            isInAnimation = false;
        }
    }

    public void ResetTime()
    {
        TimeLeft = BonusTime;
    }
}
