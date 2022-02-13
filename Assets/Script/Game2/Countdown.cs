using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float CountTime = 60f;
    bool IsEnded = false;
    IsOpen TimerTrigger;
    private void Start()
    {
        TimerTrigger = FindObjectOfType<IsOpen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerTrigger.Opened)
        { 
            if (CountTime >= 0f)
            {
                CountTime -= Time.deltaTime;
                this.GetComponent<Text>().text = ((int)CountTime).ToString();
            }
            else if (!IsEnded)
            {
                FindObjectOfType<Game2Controller>().EndGame();
                IsEnded = true;
            }
        }
    }

}
