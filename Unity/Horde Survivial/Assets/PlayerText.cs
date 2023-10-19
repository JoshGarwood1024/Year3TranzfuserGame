using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerText : MonoBehaviour
{
    public GameObject bottomText;
    public GameObject topText;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        topText.transform.position = player.transform.position + new Vector3(0, 1);
        bottomText.transform.position = player.transform.position + new Vector3(0, -1);
    }
}
