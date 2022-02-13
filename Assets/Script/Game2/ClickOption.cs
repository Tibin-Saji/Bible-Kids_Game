using UnityEngine;

public class ClickOption : MonoBehaviour
{
    public Game2Controller Controller;
    public Animator anim;
    public ParticleSystem StarBurst;
    public AudioClip WrongAnswer;

    public void CheckOption()
    {
        if (GetComponentInChildren<IntergerValue>().BookIndex == Controller.CorrectIndex)
        {
            StarBurst.Play();
            Controller.LevelComplete = true;
            anim.Play("CorrectOptionClick");
            // Sound effect connected to the particle system
        }
        else
        {
            anim.Play("WrongOptionClick");
            FindObjectOfType<AudioSource>().GetComponent<AudioSource>().PlayOneShot(WrongAnswer);
        }
    }
}
