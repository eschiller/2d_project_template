using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    Text dialogManagerTextComponenet;
    Image dialogManagerPortraitImage;


    public string[] steps;
    public Sprite[] portraits;

    private int currentStep = 0;

    // Use this for initialization
    void Start () {
        dialogManagerTextComponenet = GetComponentInChildren<Text>();

        GameObject portraitObject = GameObject.Find("DialogPortrait");
        if (portraitObject != null) {
            Debug.Log("found portrait object");
            dialogManagerPortraitImage = portraitObject.GetComponent<Image>();
            if (dialogManagerPortraitImage == null) {
                Debug.Log("didn't get the portrait image");
            }

            dialogManagerPortraitImage.color = Color.white;
        }

        GameObject panelObject = GameObject.Find("DialogPanel");
        if (panelObject != null) {
            panelObject.GetComponent<Image>().color = Color.white;
        }

        dialogManagerTextComponenet.text = steps[currentStep];
        dialogManagerPortraitImage.sprite = portraits[currentStep];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            currentStep++;
            if (currentStep >= steps.Length) {
                Destroy(transform.gameObject);
            }
            if (currentStep < steps.Length)
            {
                dialogManagerTextComponenet.text = steps[currentStep];
                dialogManagerPortraitImage.sprite = portraits[currentStep];
            }
        }
    }


}
