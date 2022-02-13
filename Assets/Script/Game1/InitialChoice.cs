using UnityEngine;
using UnityEngine.UI;

public class InitialChoice: MonoBehaviour
{
    public GameObject TutObj;
    DontDestroy _DontDestroy;
    Dropdown _DropDown;

    private void Start()
    {
        _DontDestroy = FindObjectOfType<DontDestroy>();
        _DropDown = GetComponentInChildren<Dropdown>();
    }

    private void Update()
    {
        if(_DropDown.value != 12)
        {
            GetComponentInChildren<Button>().interactable = true;
        }
        else
        {
            GetComponentInChildren<Button>().interactable = false;
        }
    }
    public void CallTutorial()
    {
        if (_DontDestroy.Game1Initial)
        {
            TutObj.SetActive(true);
        }
    }

    public void OnAnimComplete()
    {
        if (_DontDestroy.Game1Initial)
        {
            Time.timeScale = 0f;
            _DontDestroy.Game1Initial = false;
        }
        else
        {
            GameObject.Find("Menu").GetComponent<Mask>().enabled = false;
            Time.timeScale = 1f;
        }        
    }
}
