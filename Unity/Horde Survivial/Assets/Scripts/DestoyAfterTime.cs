using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }
}
