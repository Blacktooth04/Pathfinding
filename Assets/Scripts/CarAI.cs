using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarAI : MonoBehaviour {

	[SerializeField] Transform target;
    //[SerializeField] Text readout;
    [SerializeField] float acceleration = 5f;
    [SerializeField] float deceleration = 5f;
    [SerializeField] float minSpeed = 0.0f; // keep it from going backwards
    [SerializeField] float maxSpeed = 100.0f;
    [SerializeField] float brakeAngle = 20.0f;
    [SerializeField] float rotSpeed = 1.0f;
	float speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // get the targets x and z position, this objects y position
        // don't want it to track the y position, because it started behaving weirdly
        // when the target was at differenet heights
        Vector3 lookAtTarget = new Vector3(target.position.x, this.transform.position.y, target.position.z);
		Vector3 direction = lookAtTarget - this.transform.position; // get the vector3 to the target

        // rotate smoothly
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
			Quaternion.LookRotation(direction), Time.deltaTime*rotSpeed);
		
		if(Vector3.Angle(target.forward,this.transform.forward) > brakeAngle && speed > 10)
		{
			speed = Mathf.Clamp(speed - (deceleration*Time.deltaTime), minSpeed, maxSpeed);
		}
		else
		{
			speed = Mathf.Clamp(speed + (acceleration*Time.deltaTime), minSpeed, maxSpeed);
		}
		
		this.transform.Translate(0,0,speed);

        //if (readout)
			//readout.text = "" + (int)speed;
	}
}
