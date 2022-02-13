using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler
{
    public int BookIndex;
    public SceneController SC;
    public AudioClip ButtonClip;
    public AudioClip WrongAnswerClip;

    void Start()
    {
        //SC = GetComponent<SceneController>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponentInChildren<IntergerValue>().BookIndex == BookIndex)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                eventData.pointerDrag.GetComponent<DragDrop>().Locked = true;
                SC.ChangeScore(2);
                FindObjectOfType<AudioSource>().PlayOneShot(ButtonClip);
            }

            else
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPos();
                GirlAnimController.GirlSad();
                SC.ChangeScore(-1);
                FindObjectOfType<AudioSource>().PlayOneShot(WrongAnswerClip);
            }
        }
    }  
}
