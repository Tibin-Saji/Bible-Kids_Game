using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game2Controller : Constants
{
    public Text Question;
    public Text Order;
    public Text QuesNo;
    int QNumber = 0;
    public bool LevelComplete = true;
    List<string> Q_books = new List<string> (books);
    public GameObject[] options;
    public int CorrectIndex = 0;
    public GameObject LevelCompleteScreen;
    public Text QuizResult;

    public AudioClip TimerClip;

    void Update()
    {

        if (LevelComplete)
        {
           StartCoroutine(CallSetQuestion());
        }
    }

    IEnumerator CallSetQuestion()
    {
        LevelComplete = false;
        yield return new WaitForSeconds(0.75f);
        SetQuestion();
    }

    void SetQuestion()
    {
        ChangeQuestionNo();
        int i;
        do
            i = (int)Random.Range(1f, Q_books.Count - 1);
        while (Q_books[i] == "-1");
        Question.text = Q_books[i];
        Q_books[i] = "-1"; 
        SetOptions(i);
    }


    void SetOptions(int i)
    {
        CorrectIndex = i - 1 + SetOrder();                          // -1 for before and +1 for after 
        List<string> A_books = new List<string>(books);
        int CorrectOption = (int)Random.Range(0f, 4f);
        options[CorrectOption].GetComponent<TextMeshProUGUI>().SetText(A_books[CorrectIndex]);
        options[CorrectOption].GetComponent<IntergerValue>().BookIndex = CorrectIndex;
        A_books.RemoveAt(CorrectIndex);
        A_books.RemoveAt(i);
        for (int j = 0; j < options.Length; j++)
        {
            if (j != CorrectOption)
            {
                int RandomIndex = (int)Random.Range(0f, (float)A_books.Count);
                options[j].GetComponent<TextMeshProUGUI>().SetText(A_books[RandomIndex]);
                options[j].GetComponent<IntergerValue>().BookIndex = RandomIndex;
                A_books.RemoveAt(RandomIndex);
            }
        }
    }

    int SetOrder()
    {
        int i = (int)Random.Range(0f, 2f);
        Order.text = OrderText[i];
        return 2*i;
    }

    void ChangeQuestionNo()
    {
        QNumber++;
        QuesNo.text = "Q" + QNumber.ToString();
    }

    public void EndGame()
    {
        SetQuizResult();
        LevelCompleteScreen.SetActive(true);
        GetComponent<AudioSource>().clip = TimerClip;
        GetComponent<AudioSource>().Play();
    }

    void SetQuizResult()
    {
        QuizResult.text = (QNumber - 1).ToString();
    }
}
