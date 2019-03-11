using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;


public class CharacterManager : MonoBehaviour {

    public int health = 3;
    public float invulnerableTime = 1.0f;

    public bool isVulnerable = true;
    private bool isDead = false;

    protected SpriteRenderer myRenderer;

    public Transform targetTransform;

    // Update is called once per frame
    void Update () {

        //check if we're dead
        if ((health <= 0) && !isDead) {
            Die();
        }
	}


    void FlipRenderer() {
        GetComponent<SpriteRenderer>().enabled = !myRenderer.enabled;
    }


    public virtual void LoseHealth (int loss) {
        Debug.Log("health is " + health);
        health -= loss;
        MakeInvulnerable();
        StartCoroutine(SpriteEffects.BlinkSprite(transform.GetComponent<SpriteRenderer>()));
        Invoke("MakeVulnerable", invulnerableTime);
    }


    public virtual void GainHealth(int gain) {
        health += gain;
    }

    public void Die() {

        //set animation for death
        isDead = true;
        Destroy(gameObject, .40f);
        Debug.Log("about to set animation to dead");
        GetComponent<Animator>().SetBool("isDead", true);
    }

    public void SetTargetTransform(Transform t) {
        targetTransform = t;
    }

    protected void MakeVulnerable() {
        isVulnerable = true;
    }

    protected void MakeInvulnerable()
    {
        isVulnerable = false;
    }
}
