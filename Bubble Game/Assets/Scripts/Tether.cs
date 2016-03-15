using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Transform))]
[RequireComponent (typeof (Transform))]
[RequireComponent (typeof (Rigidbody))]
public class Tether : MonoBehaviour {

    
    private float length;

    //Assigned in inspector
    public Transform body;
    public Rigidbody rbody;
    public Transform tetherPoint;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(body.position, tetherPoint.position);

        if (distance > 2) {
            Vector3 force =  tetherPoint.position - body.position;
            rbody.AddForce(force * GameManager.Instance.bubbleRiseRate);
        }
        
	}
}
