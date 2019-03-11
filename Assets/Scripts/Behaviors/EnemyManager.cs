using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class EnemyManager : CharacterManager {
    public int touchDamange = 1;

    BoxCollider2D myCollider;


	// Use this for initialization
	void Start () {
        myCollider = GetComponent<BoxCollider2D>();
	}


    public override void LoseHealth(int loss)
    {
        base.LoseHealth(loss);
        StartCoroutine(CameraEffects.ShakeCamera(GameObject.FindWithTag("MainCamera")));

    }


    public override void GainHealth(int gain)
    {
        base.GainHealth(gain);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Blob hit " + other);
        if (other.transform.tag == "Player" && (health > 0) && other.gameObject.GetComponent<CharacterManager>().isVulnerable) {
            other.gameObject.GetComponent<CharacterManager>().LoseHealth(touchDamange);
        }
    }
}
