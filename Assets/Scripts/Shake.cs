using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {


    public float speed=7.5f;
    public float rangeup = 0;
    public float rangedown = -0.04f;
    private bool isOk;
	void Start () {
        isOk = false;
	}
	

	void Update () {
        //print(transform.rotation.z);
        float x = Time.deltaTime * speed;
        if (transform.rotation.z > rangeup) {
            isOk = false;
 }

        if (transform.rotation.z < rangedown) { 
            isOk = true; }
           
        if (isOk){
            transform.Rotate(0, 0, x);
        }else transform.Rotate(0, 0, -x);

	}
}
