using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAreaScript : MonoBehaviour
{
    public LogicManager logic;
    public borbScript borb;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.gameOver();
        borb.borbIsAlive = false;
    }
}