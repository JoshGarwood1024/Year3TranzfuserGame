using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PermCurrency : MonoBehaviour
{
    public static int PermCur = 0;

    public TMP_Text Perm;


    // Start is called before the first frame update
    void Start()
    {
        Perm = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Perm.text = PermCur.ToString();
    }
}
