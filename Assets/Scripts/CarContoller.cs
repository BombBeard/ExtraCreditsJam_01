using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour {

    public float carSpeed;
    public float minCarSpeed = -3f;
    public float maxCarSpeed = 10f;
    public float turnSpeed;
    public float jumpPower;

    private bool isJumping;
    private float input_f;

	// Use this for initialization
	void Start () {
        input_f = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") != null)
        {
            //rotate around Y
            transform.RotateAround(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        }
        if (Input.GetAxis("Vertical") != null)
        {
            UpdateCarSpeed(input_f);
        }

    }

    private void UpdateCarSpeed(float speed)
    {
        speed = Input.GetAxis("Vertical") / Time.deltaTime;
        speed *= 2 / carSpeed;

        speed += GetComponent<Rigidbody>().velocity.z;
        Mathf.Clamp(speed, minCarSpeed, maxCarSpeed);
        //speed += (Time.deltaTime * carSpeed);
        //Debug.Log("speed: " + speed.ToString());
        Debug.Log("Velocity: " + GetComponent<Rigidbody>().velocity.ToString());
        Vector3 tmp = (new Vector3(0f, 0f, (speed)));
        GetComponent<Rigidbody>().AddForce(tmp, ForceMode.Force);
    }
}
