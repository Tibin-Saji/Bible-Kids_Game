using UnityEngine;
using UnityEngine.UI;


public class ChangeText : Constants
{
    static Text text;
    static string Temptext;


    private void Start()
    {
        text = GetComponent<Text>();
        Temptext = text.text;
    }

    public static void LvlComTextUpdate()
    {
        text.text = JoyWords[Random.Range(0, JoyWords.Count)] + "!!! So which books comes after " + SceneController.PrevBook();
        Temptext = text.text;
    }
    public static void OptionTextUpdate()
    {
        text.text =  "What comes after " + SceneController.PrevBook();
        Temptext = text.text;
    }

    public static void InitialSpeech()
    {
        text.text = "Can you help me arrange the Books?";
        Temptext = text.text;
    }

    public static void TextSad()
    {
        text.text = "I don't think that was the correct position";
    }

    public static void PrevLine()
    {
        text.text = Temptext;
    }
}