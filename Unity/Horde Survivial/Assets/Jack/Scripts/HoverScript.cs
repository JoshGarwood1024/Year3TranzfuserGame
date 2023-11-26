using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HoverScript : MonoBehaviour
{
    public GameObject hovText;
    // public TextMeshProUGUI hoverText;
    // public string displayMessage = "...";

    public void Start()
    {
        hovText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
        hovText.SetActive(true);
        // hoverText.text = displayMessage;
        // hoverText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        hovText.SetActive(false);
        // hoverText.gameObject.SetActive(false);
    }
}
