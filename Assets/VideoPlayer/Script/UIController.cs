using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour /*, IPointerEnterHandler, IPointerExitHandler*/
{
    [SerializeField] bool isOnUI;
    public void ObjectEnabler(bool val)
    {
        Debug.Log("Enter");
        if (!isOnUI)
        {
            transform.gameObject.SetActive(val);
        }
    }
    /*public void OnPointerEnter(PointerEventData eventData)
    {
        isOnUI = true;
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOnUI = false;
        Debug.Log("Exit");
    }*/
}
