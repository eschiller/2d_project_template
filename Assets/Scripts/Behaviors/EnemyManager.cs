using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : CharacterManager {
    public int touchDamange = 1;

    BoxCollider2D myCollider;


	// Use this for initialization
	void Start () {
        myCollider = GetComponent<BoxCollider2D>();
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Blob hit " + other);
        if (other.transform.tag == "Player" && (health > 0) && other.gameObject.GetComponent<CharacterManager>().isVulnerable) {
            other.gameObject.GetComponent<CharacterManager>().LoseHealth(touchDamange);
        }
    }
}
