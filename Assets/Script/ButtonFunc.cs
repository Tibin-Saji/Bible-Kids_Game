using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class ButtonFunc : MonoBehaviour
{
    public Animator InformationBarAnim;
    public GameObject InfoPanel;
    public bool isInInfo = false;

    public Animator Transition;
    public float WaitTime = 2f;

    public Animator MenuBarAnim;
    bool isInMenu = false;
    public GameObject BlackTint;

    public Animator InitialChoice;

    public Transform Game1Button;
    public GameObject Game1Text;
    public Transform Game2Button;
    public GameObject Game2Text;
    public GameObject TextArea;


    Vector3 scaleUP = new Vector3 ( 1.2f, 1.2f, 1 );
    Vector3 scaleDOWN = new Vector3 ( 1, 1, 1 );

    public void InformationButton()
    {
        if (!isInInfo)
        {
            InformationBarAnim.Play("Information");
            InfoPanel.SetActive(true);
            isInInfo = true;
        }
        else
        {
            InformationBarAnim.Play("InformationClose");
            InfoPanel.SetActive(false);
            isInInfo = false;
        }
        InformationBarAnim.SetBool("isInInfo", isInInfo);
    }

    public void InGameMenu()
    {
        isInMenu = !isInMenu;
        if (isInMenu)
        {
            MenuBarAnim.Play("InGameOption");
            BlackTint.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            if(FindObjectOfType<SceneController>().OptionChanged)
                FindObjectOfType<SceneController>().OptionStart();
            MenuBarAnim.Play("InGameOptionExit");
            Time.timeScale = 1f;
        }
    }

    public void StartPage()
    {
        StartCoroutine(WaitAndTransition("Menu"));
        FindObjectOfType<AudioFade>().GetComponent<AudioFade>().CheckFadeOut();
        Time.timeScale = 1f;
    }

    public void Game1()
    {
        StartCoroutine(WaitAndTransition("Game1"));
        FindObjectOfType<AudioFade>().GetComponent<AudioFade>().CheckFadeOut();

    }

    public void Game2()
    {
        StartCoroutine(WaitAndTransition("Game2"));
        FindObjectOfType<AudioFade>().GetComponent<AudioFade>().CheckFadeOut();

    }

    public void Guide()
    {
        FindObjectOfType<AudioFade>().GetComponent<AudioFade>().CheckFadeOut();
        StartCoroutine(WaitAndTransition("Guide"));

    }

    IEnumerator WaitAndTransition(string Scene)
    {
        Transition.Play("TransitionClose");

        yield return new WaitForSeconds(WaitTime);

        SceneManager.LoadScene(Scene);
    }

    public void EnterGame1()
    {
        FindObjectOfType<SceneController>().OptionStart(true);
        InitialChoice.Play("InitialChoiceFadeOut");
    }

    public void Game1Guide()
    {
        if (!TextArea.activeSelf)
        {
            TextArea.SetActive(true);
        }
        Game1Button.localScale = scaleUP;
        Game2Button.localScale = scaleDOWN;
        Game2Text.SetActive(false);
        Game1Text.SetActive(true);
    }

    public void Game2Guide()
    {
        if (!TextArea.activeSelf)
        {
            TextArea.SetActive(true);
        }
        Game2Button.localScale = scaleUP;
        Game1Button.localScale = scaleDOWN;
        Game1Text.SetActive(false);
        Game2Text.SetActive(true);
    }
}
