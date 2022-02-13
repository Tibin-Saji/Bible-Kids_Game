using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SceneController : Constants
{
    public GameObject[] slots;
    public GameObject[] textMesh = new GameObject[8];

    public GameObject SlotPrefab;
    public GameObject slotParent;
    public GameObject[] EvenPos;
    public GameObject[] OddPos;

    static int BookIndex = 0;
    static int noBooks = 0;
    static int noOfSlots;
    static List<string> D_books;

    public GameObject BGParent;
    
    public GameObject IntroName;
    public GameObject TypeName;
    public string TypeNameString;
    public GameObject Part;
    public int partNo = 0;
    public Animator typeDisplay;
    public bool TypeDisplayCompleted = false;

    public static bool LevelComplete = false;
    bool wasLevelComplete = false;
    static bool CheckForLevelComplete = true;
    bool isContinuous = true;
    bool isOT = false;

    public bool OptionChanged = false;
    public Dropdown InitialDropDown;
    public Dropdown InGameDropDown;

    public TextMeshProUGUI ScoreText;
    public int TotalScore;
    public int score = 0;
    static int ScoreAddition;
    public float WaitScoreAnim = 2f;
    float ScoreCountdown = 0f;
    bool hasDisplayed = false;

    BonusTimer Timer;
    public ParticleSystem BonusConfetti;
    public GameObject[] FinalConfettis;
    public GameObject[] Stars;

    public GameObject GameCompleteScene;

    public AudioClip VictoryClip;

    void Start()
    {
        Timer = FindObjectOfType<BonusTimer>();
        BonusConfetti = FindObjectOfType<ParticleSystem>();
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (LevelComplete)
        {
            wasLevelComplete = true;

            Timer.runTimer = false;

            LevelComplete = false;

            ScoreAnimController.positiveScore();
           
            if(Timer.TimeLeft > 0)
            {
                BonusConfetti.Play();

                ChangeScore(5);
            }

            StartCoroutine(CallDisplayType());
        }

        ScoreAnim();

        if (CheckForLevelComplete)
        { 
            LevelCompleteCheck(); 
        }

        if (wasLevelComplete)
        {
            if (TypeDisplayCompleted)                // Alternative for calling OnLevelComplete from the animation directly
            {
                if (!isEndOfGame())                    // Keep func to check end of game
                {
                    wasLevelComplete = false;
                    TypeDisplayCompleted = false;
                    OnLevelComplete();
                }
                else
                {
                    EndOfGame();
                }
            }
        }
        
    }


    public void GameSetter()
    {
        noOfSlots = sceneSlots[BookIndex];
        GetNoBooks();
        ResetDialoge();
        AssignDialoge();
        AssignSlot();

        Timer.ResetTime();
        Timer.runTimer = true;

        CheckForLevelComplete = true;

        DisplayScore();
    }

    public void OptionStart(bool isInitialChoice = false)
    {
        if(!isInitialChoice)
        {
            DestroySlots();
        }
        else
        {
            InGameDropDown.value = InitialDropDown.value;         // Change the item selected from initial in ingame dropdown
        }

        GameSetter();

        UpdateSpeechBubble();

        if (OptionChanged)
        {
            OptionChanged = false;
            score = 0;
            DisplayScore();
        }
    }

    void OnLevelComplete()
    {
        NextLevel();

        OptionStart();

        UpdateSpeechBubble();
    }

    void LevelCompleteCheck()
    {
        int count = 0;
        for (int i = 0; i < textMesh.Length; i++)
        {
            if (textMesh[i].GetComponentInParent<DragDrop>().Locked)
                count++;
            if (count == noOfSlots && count > 0)
            {
                LevelComplete = true;
                CheckForLevelComplete = false;
                break;
            }
        }
    }

    public void GetBookIndex(int value, bool isContinuous = false, bool isOT = false)
    {
        BookIndex = value;
        this.isContinuous = isContinuous;
        this.isOT = isOT;
    }

    bool isEndOfGame()
    {
        if (!isContinuous)
        {
            if (types[BookIndex] != types[BookIndex + 1])
            {
                return true;
            }
        }
        else
        {
            if (isOT)
            {
                if (types[BookIndex + 1] == "Gospels")
                {
                    return true;
                }
            }
            else if (types[BookIndex + 1] == "End Of List")
            {
                return true;
            }
        }
        return false;
    }

    static public string PrevBook()
    {
        return books[noBooks - 1];
    }
    void GetNoBooks()
    {
        noBooks = 0;
        for (int i = 0; i < BookIndex; i++)
        {
            noBooks += sceneSlots[i];
        }
    }

    void NextLevel()
    {
        BookIndex++;
    }

    void AssignDialoge()
    {
        D_books = new List<string>(books);
        for (int i = 0; i < noOfSlots; i++) // assign initial
        {
            int j;

            do
                j = Random.Range(0, textMesh.Length);
            while (textMesh[j].GetComponent<IntergerValue>().BookIndex != -1);

            textMesh[j].GetComponent<TextMeshProUGUI>().SetText(D_books[noBooks + i]);
            textMesh[j].GetComponent<IntergerValue>().BookIndex = noBooks + i;
        }

        for (int i = 0; i < noOfSlots; i++) // remove initial
        {
            D_books.RemoveAt(noBooks);
        }

        for (int i = 0; i < textMesh.Length; i++) // assign random
        {
            if (textMesh[i].GetComponent<IntergerValue>().BookIndex == -1)
            {
                int rand = Random.Range(0, D_books.Count);
                textMesh[i].GetComponent<TextMeshProUGUI>().SetText(D_books[rand]);
                textMesh[i].GetComponent<IntergerValue>().BookIndex = -2;

                D_books.RemoveAt(rand);
            }
        }
    }

    void AssignSlot()
    {
        slots = new GameObject[noOfSlots];
        if (noOfSlots % 2 == 0)
            evenSlots();
        else
            oddSlots();

        AssignBookBookIndex();
    }

    void evenSlots()
    {
        for (int j = 0, i = (3 - noOfSlots / 2); j < noOfSlots; i++, j++) 
        {
            slots[j] = Instantiate(SlotPrefab, EvenPos[i].transform.position, Quaternion.identity, slotParent.transform);
            slots[j].SetActive(true);
        }
    }

    void oddSlots()
    {

        for (int j = 0, i = (2 - (noOfSlots - 1) / 2); j < noOfSlots; i++, j++)
        {
            slots[j] = Instantiate(SlotPrefab, OddPos[i].transform.position, Quaternion.identity, slotParent.transform);
            slots[j].SetActive(true);
        }
    }

    void AssignBookBookIndex()
    {
        for (int i = 0; i < noOfSlots; i++)
        {
            slots[i].GetComponent<SlotController>().BookIndex = noBooks + i;
        }
    }

    void ResetDialoge()
    {
        for (int i = 0; i < textMesh.Length; i++)
        {
            textMesh[i].GetComponent<IntergerValue>().BookIndex = -1;
            textMesh[i].GetComponentInParent<DragDrop>().ResetDialog();
        }
    }

    void DestroySlots()
    {
        if (slots != null)
            foreach (GameObject i in slots)
            {
                Destroy(i);   
            }
    }


    void DisplayType()
    {
        if (noOfSlots == 1)
            IntroName.GetComponent<TextMeshProUGUI>().SetText("It is");
        else
            IntroName.GetComponent<TextMeshProUGUI>().SetText("They are");

        TypeNameString = types[BookIndex];
        TypeName.GetComponent<TextMeshProUGUI>().SetText(TypeNameString);

        if ((BookIndex > 0) && (BookIndex < types.Capacity - 2))
        {
            if ((types[BookIndex] == types[BookIndex + 1]) || (types[BookIndex] == types[BookIndex - 1]))
            {
                ++partNo;
            }
            else
            {
                partNo = 0;
            }
        }

        if (partNo == 0)
        {
            Part.GetComponent<TextMeshProUGUI>().SetText("");
        }
        else
        {
            Part.GetComponent<TextMeshProUGUI>().SetText("pt. " + partNo.ToString());
        }

        typeDisplay.Play("DisplayType1");        
    }
    IEnumerator CallDisplayType()
    {
        yield return new WaitForSeconds(2f);
        DisplayType();
    }

    void EndOfGame()
    {
        StartCoroutine("EndOfGameCo");
    }
    IEnumerator EndOfGameCo()
    {
        GameCompleteScene.SetActive(true);

        int Stars = (int)score * 3 / TotalScore;
        yield return new WaitForSeconds(0.75f);


        for (int i = 0; i < Stars; i++)
        {
            this.Stars[i].SetActive(true);
            FinalConfettis[i].SetActive(true);
            yield return new WaitForSeconds(0.75f);

        }
    }

    public void ChangeScore(int a)
    {
        score += a;
        ScoreAddition = a;
    }

    void DisplayScore()
    {
        ScoreText.SetText(score.ToString());
        hasDisplayed = true;
    }

    void UpdateSpeechBubble()
    {
        if(BookIndex == 0)
        {
            ChangeText.InitialSpeech();
        }
        else
        {
            if (OptionChanged)
            {
                ChangeText.OptionTextUpdate();
            }
            else
            {
                ChangeText.LvlComTextUpdate();
            }
        }
    }

    void ScoreAnim()
    {
        switch (ScoreAddition)
        {
            case -1:
                ScoreAnimController.negativeScore();
                ScoreCountdown = WaitScoreAnim;
                hasDisplayed = false;
                break;
            case 2:
                ScoreAnimController.positiveScore();
                ScoreCountdown = WaitScoreAnim;
                hasDisplayed = false;
                break;
            case 5:
                ScoreAnimController.bonusScore();
                ScoreCountdown = WaitScoreAnim;
                hasDisplayed = false;
                break;
        }
        ScoreAddition = 0;
        if(ScoreCountdown > 0f)                         
            ScoreCountdown -= Time.deltaTime;
        if(ScoreCountdown <= 0f && !hasDisplayed)
            DisplayScore();
    }

}
