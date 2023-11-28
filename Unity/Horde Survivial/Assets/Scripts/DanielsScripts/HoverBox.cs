using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverBoxGameObject;

    [TextArea(3,5)]
    public string Description;
    
    float timeHovering;
    bool hovering;


    private void Update()
    {
        if (hovering) timeHovering += Time.deltaTime;

        if(timeHovering > 0.5f && !HoverBoxGameObject.activeSelf)
        {
            HoverBoxGameObject.SetActive(true);
            HoverBoxGameObject.GetComponentInChildren<TextMeshProUGUI>().text = TryGetComponent<UpgradeTesting>(out UpgradeTesting ut) ? Description + "\nCost: " + ut.GetCost() : Description;
            HoverBoxGameObject.transform.position = Input.mousePosition - new Vector3(-100, 60);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (HoverBoxGameObject.activeSelf) HoverBoxGameObject.SetActive(false);
        hovering = false;
        timeHovering = 0.0f;
    }
}
