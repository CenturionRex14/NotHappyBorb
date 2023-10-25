using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borbScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicManager logic;
    public bool borbIsAlive = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && borbIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            animator.SetBool("borbFlaps", true);
        }
        else
        {
            animator.SetBool("borbFlaps", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        borbIsAlive = false;
    }

}

