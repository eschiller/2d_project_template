using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform ownerObject = null;
    public float throwspeed = 400;
    public float throwheight = 5.0f;
    public int throwDamage = 1;
    public int attackDamage = 1;
    public bool trackParentAnimatorVariables = true;

    public string ownerUseAnimationTrigger = "attack1";
    public string itemUseAnimationTrigger = "attack1";

    PlatformerController2D pControl;
    Animator myAnimator;
    SpriteRenderer myRenderer;
    BoxCollider2D myCollider;

    public bool resizeDuringUse = true;
    public bool attackDuringUse = true;
    public float attackDuration = 0.2f;
    public float useDuration = 0.2f;
    public float useResizeX = 1.0f;
    public float useResizeY = 1.0f;
    public float useOffsetX = 0.0f;
    public float useOffsetY = 0.0f;

    public bool debugMessages = false;

    private bool syncAnimator = false;
    private bool thrown = false;
    private bool attacking = false;
    private bool usingItem = false;

    private float oldColliderSizeX;
    private float oldColliderSizeY;
    private float oldColliderOffsetX;
    private float oldColliderOffsetY;
    private bool lastFlipX;

    // Use this for initialization
    void Start()
    {
        pControl = GetComponent<PlatformerController2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("thrown is " + thrown);
        if (ownerObject != null)
        {
            transform.position = ownerObject.position;
            GetComponent<SpriteRenderer>().flipX = ownerObject.GetComponent<SpriteRenderer>().flipX;
        }

        if (trackParentAnimatorVariables) {
            if (ownerObject != null) {
                UpdateAnimatorFromParent();
            }
        }

        if (pControl.canJump) {
            Debug.Log("setting thrown to false because we can jump");
            thrown = false;
        }

        //flip the collider if the renderer has
        if (myRenderer.flipX != lastFlipX) {
            myCollider.offset = new Vector2((myCollider.offset.x * -1), myCollider.offset.y);
            lastFlipX = myRenderer.flipX;
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
        pControl.canJump = false;
        thrown = true;
    }


    public void UseItem() {
        if (!usingItem)
        {
            usingItem = true;
            Invoke("EndUse", useDuration);

            Debug.Log("in use item");

            if (ownerUseAnimationTrigger != null)
            {
                Animator ownerAnimator = ownerObject.GetComponent<Animator>();
                ownerAnimator.SetTrigger(ownerUseAnimationTrigger);
            }

            if (itemUseAnimationTrigger != null)
            {
                GetComponent<Animator>().SetTrigger(itemUseAnimationTrigger);
            }

            if (resizeDuringUse)
            {
                resizeCollider(useResizeX, useResizeY, useOffsetX, useOffsetY);
                Invoke("RevertCollider", useDuration);
            }

            if (attackDuringUse)
            {
                attacking = true;
                Invoke("EndAttack", attackDuration);
            }
        }
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


    void resizeCollider(float sizeMultiplierX = 1, float sizeMultiplierY = 1, float newOffsetX = 0, float newOffsetY = 0)
    {
        oldColliderSizeX = myCollider.size.x;
        oldColliderSizeY = myCollider.size.y;
        oldColliderOffsetX = myCollider.offset.x;
        oldColliderOffsetY = myCollider.offset.y;
        
        if (debugMessages)
        {
            Debug.Log("old offset " + myCollider.offset);
            Debug.Log("old size " + myCollider.size);
        }

        float newSizeY = myCollider.size.y * sizeMultiplierY;
        float newSizeX = myCollider.size.x * sizeMultiplierX;
        Debug.Log("changing collider size to " + newSizeX + "," + newSizeY);


        myCollider.size = new Vector2(newSizeX, newSizeY);

        Debug.Log("collider size is now " + myCollider.size);

        if (myRenderer.flipX) {
            newOffsetX *= -1;
        }
        myCollider.offset = new Vector2(newOffsetX, newOffsetY);

        if (debugMessages)
        {
            Debug.Log("new offset " + myCollider.offset);
            Debug.Log("new size " + myCollider.size);
        }
    }


    void RevertCollider() {
        myCollider.size = new Vector2(oldColliderSizeX, oldColliderSizeY);
        myCollider.offset = new Vector2(oldColliderOffsetX, oldColliderOffsetY);
    }


    void EndAttack() {
        attacking = false;
    }


    void EndUse() {
        usingItem = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Spear hit " + collision.gameObject.name);
        Debug.Log("attacking is " + attacking);
        Debug.Log("Thrown is " + thrown);

        if ((throwDamage > 0) && (thrown) && (collision.transform.tag == "Enemy")) {
            collision.gameObject.GetComponent<CharacterManager>().LoseHealth(throwDamage);
        }

        if (attacking && (collision.transform.tag == "Enemy"))
        {
            collision.gameObject.GetComponent<CharacterManager>().LoseHealth(attackDamage);
        }
    }
}
