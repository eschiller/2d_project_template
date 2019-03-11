using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Vector3 myPos;
	public Transform myPlay;

	// Use this for initialization
	void Start () {
	}
	//var myPos : Vector3;
	//var myPlay : Transform;



	void Update()
	{
        if (myPlay != null)
        {
            transform.position = myPlay.position + myPos + new Vector3(0, 0, -1);
        }
	}
}
