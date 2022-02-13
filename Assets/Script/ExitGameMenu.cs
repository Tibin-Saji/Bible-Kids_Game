using UnityEngine;

public class ExitGameMenu : MonoBehaviour
{
    public GameObject MenuBar;
    public GameObject BlackTint;

    // Start is called before the first frame update
    void ExitInGameMenu()
    {
        BlackTint.SetActive(false);
    }
}
