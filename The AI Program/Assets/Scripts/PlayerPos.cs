using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{


    private GameMaster gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }



    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)){}
    }
}
