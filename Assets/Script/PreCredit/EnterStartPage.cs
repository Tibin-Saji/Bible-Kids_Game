using UnityEngine.SceneManagement;
using UnityEngine;

public class EnterStartPage : MonoBehaviour
{
    public void GoToStartPage()
    {
        SceneManager.LoadScene("Menu");
    }
}
