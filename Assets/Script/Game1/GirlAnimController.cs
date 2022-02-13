using UnityEngine;

public class GirlAnimController : MonoBehaviour
{
    static Animator GirlAnim;

    // Start is called before the first frame update
    void Start()
    {
        GirlAnim = GetComponent<Animator>();
    }

    public static void GirlSad()
    {
        ChangeText.TextSad();
        GirlAnim.Play("GirlSad");

    }

    public static void GirlWave()
    {
        GirlAnim.Play("GirlWave");
    }

    public static void GirlBlink()
    {
        GirlAnim.Play("GirlBlink");
    }

    public void PrevAnim()
    {
        ChangeText.PrevLine();
    }

}
