using UnityEngine;
using UnityEngine.UI;

public class G1TutorialController : MonoBehaviour
{
    SceneController SC;

    Animator Anim;

    public GameObject[] TutScenes;

    public GameObject MainTint;
    public GameObject MenuButton;
    public GameObject MenuTint;
    public GameObject TimerTint;
    public GameObject SlotHolderTint;
    public GameObject[] DialogTint;

    int Index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        SC = FindObjectOfType<SceneController>();
        SC.OptionStart();
        FindObjectOfType<BonusTimer>().ResetTime();
        Time.timeScale = 0f;
        MainTint.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);       //For the first Child of this obj i.e. "Click to Continue"

        TutScenes[Index].SetActive(true);
        HighlightObj();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Index <= 3)
        {
            MouseClicked();
        }
    }

    private void MouseClicked()
    {
        Index++;

        for (int i = 0; i < TutScenes.Length; i++)
        {
            TutScenes[i].SetActive(false);
        }

        HighlightObj();
    }

    void HighlightObj()
    {
        switch (Index)
        {
            case 0:
                TutScenes[Index].SetActive(true);
                MenuTint.SetActive(true);
                TimerTint.SetActive(true);
                break;
            case 1:
                TutScenes[Index].SetActive(true);
                SlotHolderTint.SetActive(true);
                ActivateDialogTint();
                ActivateSlotTint();
                TimerTint.SetActive(false);
                break;
            case 2:
                TutScenes[Index].SetActive(true);
                TimerTint.SetActive(true);
                MenuTint.SetActive(false);
                break;
            case 3:
                Anim.Play("G1TutFadeOut");
                MainTint.GetComponent<Animator>().Play("G1TutFadeOutTint");
                DeactivateDialogTint();
                DeactivateSlotTint();
                SlotHolderTint.SetActive(false);
                TimerTint.SetActive(false);
                Time.timeScale = 1f;
                MenuTint.GetComponentInParent<Mask>().enabled = false;
                break;

                default:
                break;
        }
    }

    void ActivateSlotTint()
    {
        for (int i = 0; i < SC.slots.Length; i++)
        {
            SC.slots[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void ActivateDialogTint()
    {
        for (int i = 0; i < DialogTint.Length; i++)
        {
            DialogTint[i].SetActive(true);
        }
    }

    void DeactivateSlotTint()
    {
        for (int i = 0; i < SC.slots.Length; i++)
        {
            SC.slots[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void DeactivateDialogTint()
    {
        for (int i = 0; i < DialogTint.Length; i++)
        {
            DialogTint[i].SetActive(false);
        }
    }
}
