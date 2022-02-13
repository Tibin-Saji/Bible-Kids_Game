using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool Game1Initial = true;
    public bool Game2Initial = true;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
