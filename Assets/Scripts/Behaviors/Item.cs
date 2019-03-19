using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform ownerObject;
    public float throwspeed = 400;
    public float throwheight = 5.0f;
    public int throwDamage = 1;
    public bool trackParentAnimatorVariables = true;

    PlatformerController2D pControl;
    Animator myAnimator;

    private bool syncAnimator = false;
    private bool thrown = false;

    // Use this for initialization
    void Start()
    {
        pControl = GetComponent<PlatformerController2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ownerObject != null)
        {
            transform.position = ownerObject.position;
        }

        if (trackParentAnimatorVariables) {
            if (ownerObject != null) {
                UpdateAnimatorFromParent();
            }
        }
        GetComponent<SpriteRenderer>().flipX = ownerObject.GetComponent<SpriteRenderer>().flipX;

        if (pControl.canJump) {
            thrown = false;
        }
    }

    public void grabItem(Transform newOwner) {
        pControl.disable();
        ownerObject = newOwner;
        if (myAnimator != null) {
            myAnimator.SetBool("hasOwner", true);
            syncAnimator = true;
        }
    }

    public void throwItem(Vector2 direction) {
        Debug.Log("throwing item");
        ownerObject = null;
        pControl.enable();
        pControl.setActiveXVel(1f *  direction.x);
        pControl.speed = throwspeed;
        pControl.setYVel(throwheight);
        if (myAnimator != null)
        {
            myAnimator.SetBool("hasOwner", false);
        }
        thrown = true;
    }


    public void UseItem() {

    }


    void UpdateAnimatorFromParent() {
        Animator ownerAnimator = ownerObject.GetComponent<Animator>();
        myAnimator.SetFloat("runVelocity", ownerAnimator.GetFloat("runVelocity"));
        myAnimator.SetBool("isJumping", ownerAnimator.GetBool("isJumping"));
        myAnimator.SetBool("isDead", ownerAnimator.GetBool("isDead"));
        myAnimator.SetBool("isDucking", ownerAnimator.GetBool("isDucking"));

        if (syncAnimator) {
            float ont = ownerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log("Current owner normalized time is " + ont);
            myAnimator.Play(myAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, ont);
        }
        syncAnimator = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((throwDamage > 0) && (thrown) && (collision.transform.tag == "Enemy")) {
            collision.gameObject.GetComponent<CharacterManager>().LoseHealth(throwDamage);
        }
    }
}
