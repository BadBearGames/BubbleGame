using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GameObject))]
public class Tether : MonoBehaviour {

    
    private float length;

    //Assigned in inspector
    public GameObject bubbleObject;
	private Rigidbody bubbleRB;
    public float tetherDistance;

	// Use this for initialization
	void Start () {
		bubbleRB = bubbleObject.GetComponent<Rigidbody>();
		if(!bubbleRB){
			Debug.Log(name+" does NOT have a RigidBody!");
		}
	}
	
	// Update is called once per frame
	void Update () {
        
        float distance = Vector3.Distance(bubbleObject.transform.position, transform.position);

		if (distance > tetherDistance) {
            //Gets the Force Direction 
            Vector3 force =  transform.position - bubbleObject.transform.position;
            force = force.normalized;

            //Keeps the object in range of the tether
            Vector3 getBack = force * (distance - tetherDistance);
            bubbleObject.transform.Translate(getBack);

            //Neutralizes the Bubble Rise Rate, object needs this to swing
            bubbleRB.AddForce(force * GameManager.Instance.bubbleRiseRate);
        }

		Debug.DrawLine(bubbleObject.transform.position, transform.position, Color.white);
        
	}
}
