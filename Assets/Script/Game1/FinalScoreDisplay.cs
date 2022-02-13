using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{
    static Text Score;
    SceneController SC;

    void Start()
    {
        Score = GetComponent<Text>();
        SC = FindObjectOfType<SceneController>();
        Score.text = SC.score.ToString();
    }
}
