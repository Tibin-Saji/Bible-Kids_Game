using UnityEngine;

public class LevelAnim : MonoBehaviour
{
    public SceneController SC;
    public GameObject BG;
    public void ActivationTypeDisplay()
    {
        BG.SetActive(!BG.activeSelf);
    }

    public void OnAnimCompletion()
    {
        SC.TypeDisplayCompleted = true;
    }
}
