using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betweenPipesScript : MonoBehaviour
{
    public LogicManager logic;
    public borbScript borb;
    private int borbLayer = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("logic");

        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
        borb = GameObject.FindGameObjectWithTag("Player").GetComponent<borbScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.layer == borbLayer && borb.borbIsAlive) 
        {
            logic.addScore(1);
        }
    }
}
