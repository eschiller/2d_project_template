using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerInput : MonoBehaviour {
    float directionInputX, directionInputY;
    public PlatformerController2D myPlatformerPhysics;
    bool jumping;
    bool unJumping;
    bool hasItem;
    bool action1;


	// Use this for initialization
	void Start () {
        hasItem = false;
	}
	
	// Update is called once per frame
	void Update () {
        directionInputX = Input.GetAxisRaw("Horizontal");
        directionInputY = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButtonDown("Jump");
        unJumping = Input.GetButtonUp("Jump");
        action1 = Input.GetButtonDown("Fire1");

        if (directionInputY < -.3f) {
            myPlatformerPhysics.Duck();
        } else {
            myPlatformerPhysics.Unduck();
        }

        if (jumping)
        {
            myPlatformerPhysics.Jump();
        }

        if (unJumping)
        {
            myPlatformerPhysics.ReleaseJump();
        }

        if (action1) {
            myPlatformerPhysics.Attack();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("KEY DOWN E");
            if (hasItem)
            {
                Debug.Log("threw item in input");
                myPlatformerPhysics.throwItem();
                hasItem = false;
            }
            else
            {
                if (myPlatformerPhysics.grabItem())
                {
                    Debug.Log("grabbed item in input");
                    hasItem = true;
                }
            }
        }
        myPlatformerPhysics.setActiveXVel(directionInputX);
    }
}
