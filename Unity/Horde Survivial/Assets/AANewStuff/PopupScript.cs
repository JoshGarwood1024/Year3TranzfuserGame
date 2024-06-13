using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopupScript : MonoBehaviour
{

    public TMP_Text popupText;

    private GameObject window;
    private Animator popupanim;

    public Queue<string> popupQueue;
    private Coroutine queuechecker;

    public void AddtoQueue(string text)
    {
        popupQueue.Enqueue(text);
        if (queuechecker == null)
            queuechecker = StartCoroutine(CheckQueue());

    }


    private void ShowPopup(string text)
    {
        window.SetActive(true);
        popupText.text = "Achievement Unlocked";
        popupanim.Play ("Achieve2");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupQueue.Dequeue());
            do
            {
                yield return null;
            }
            while (!popupanim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));

        } while (popupQueue.Count > 0);
        window.SetActive(false);
        queuechecker = null;
    }



    // Start is called before the first frame update
    void Start()
    {
        window = transform.GetChild(0).gameObject;
        popupanim = window.GetComponent<Animator>();
        window.SetActive(false);
        popupQueue = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
