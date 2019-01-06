﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDManager : MonoBehaviour {

    Text middleText;
    public GameObject healthIcon;
    GameObject allCanvas;

	// Use this for initialization
	void Start () {
        allCanvas = GameObject.Find("AllCanvas");
        middleText = transform.Find("AllCanvas/MiddleText").GetComponent<Text>();
        middleText.enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PauseGame() {
        middleText.text = "Paused";
        middleText.enabled = true;
    }

    public void UnpauseGame()
    {
        middleText.text = "";
        middleText.enabled = false;
    }


    public void SetHealth(int health, int xPadding = 16, int yPadding = -16, int spacing = 48) {
        for (int i = 0; i < health; i++) {
            GameObject aHeart;
            aHeart = Instantiate(healthIcon, new Vector3((xPadding + (spacing * i)), yPadding, -1), Quaternion.identity);
            aHeart.transform.SetParent(allCanvas.transform, false);
        }
    }
}
