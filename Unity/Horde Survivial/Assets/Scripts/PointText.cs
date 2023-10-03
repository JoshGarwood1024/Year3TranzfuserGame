using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointText : MonoBehaviour
{
    private void Update()
    {
        if(GetComponent<TextMeshProUGUI>().color.a == 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
