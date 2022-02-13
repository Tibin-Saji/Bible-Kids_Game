using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    readonly static public List<string> books =
    new List<string> { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Songs", "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi",
                        "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation"};
   
    readonly static public List<string> types =
    new List<string> { "Pentateuch", "Historical Books OT", "Historical Books OT", "Poetic Books", "Major Prophets", "Minor Prophets", "Minor Prophets", "Gospels", "Historical Book NT", "Epistles", "Epistles", "Epistles", "Epistles", "Prophetic Book", "End Of List" };
    
    readonly static public List<string> JoyWords =
    new List<string> { "Hooray", "Fantastic", "Hats off!", "Nice going", "You rock!", "Way to go", "Impressive" };

    readonly static public int[] TotalScores = {202, 113, 89, 15, 34, 15, 15, 34, 13, 7, 17, 45, 7};

    readonly static public int[] sceneSlots = { 5, 6, 6, 5, 5, 6, 6, 4, 1, 6, 5, 5, 5, 1, 0 };

    readonly public string[] OrderText = { "before", "after" };

}
