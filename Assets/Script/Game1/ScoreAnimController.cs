using UnityEngine;

public class ScoreAnimController : MonoBehaviour
{
    static Animator ScoreAnim;
    // Start is called before the first frame update
    void Start()
    {
        ScoreAnim = GetComponent<Animator>();
    }
    
    public static void negativeScore()
    {
        ScoreAnim.Play("negativeScore");
    }

    public static void positiveScore()
    {
        ScoreAnim.Play("positiveScore");
    }

    public static void bonusScore()
    {
        ScoreAnim.Play("bonusScore");
    }
}
