using UnityEngine;
using UnityEngine.UI;

public class TypeDropdown : Constants
{
    SceneController SC;
    public Text FinalTypeText;
    public Text TotalScore;
    private void Start()
    {
        SC = FindObjectOfType<SceneController>();
        //DropdownValue(0);                   //For the game to initially start with "All"
        GetComponent<Dropdown>().value = 12;
    }

    public void DropdownValue(int value)
    {
        switch (value)                          
        {
            case 0:                             // All
                SC.GetBookIndex(0, true);
                FinalTypeText.text = "All The Books";
                break;
            case 1:                             // OT
                SC.GetBookIndex(0, true, true);
                FinalTypeText.text = "Old Testament";
                break;
            case 2:                             // NT
                SC.GetBookIndex(7, true);
                FinalTypeText.text = "New Testament";
                break;
            case 3:                             // Pentatuch
                SC.GetBookIndex(0);
                FinalTypeText.text = "Pentatuch";
                break;
            case 4:
                SC.GetBookIndex(1);
                FinalTypeText.text = "Historical Books OT";
                break;
            case 5:
                SC.GetBookIndex(3);
                FinalTypeText.text = "Poetic Books";
                break;
            case 6:
                SC.GetBookIndex(4);
                FinalTypeText.text = "Major Prophets";
                break;
            case 7:
                SC.GetBookIndex(5);
                FinalTypeText.text = "Minor Prophets";
                break;
            case 8:
                SC.GetBookIndex(7);
                FinalTypeText.text = "Gospels";
                break;
            case 9:
                SC.GetBookIndex(8);
                FinalTypeText.text = "Gistorical Book NT";
                break;
            case 10:
                SC.GetBookIndex(9);
                FinalTypeText.text = "Epistels";
                break;
            case 11:
                SC.GetBookIndex(13);
                FinalTypeText.text = "Prophetic Book";
                break;

            default:
                break;
        }
        SC.partNo = 0;
        SC.OptionChanged = true;
        SC.TotalScore = Constants.TotalScores[value];
        TotalScore.text = Constants.TotalScores[value].ToString();
    }
}
