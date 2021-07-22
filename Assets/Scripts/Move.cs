using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed=0.1f;
    private float timer = 0;
    private bool ok = true;
	void Update () {
        timer += Time.deltaTime;
        
     //   gameObject.transform.Rotate(new Vector3(0,0,0.2f));
      // print(gameObject.transform.rotation.z);
       // print(ok);
       if (gameObject.transform.rotation.z > 0.01f) ok = false;
       if (gameObject.transform.rotation.z < -0.07f) ok = true;
       if (ok)
       {

           gameObject.transform.Rotate(new Vector3(
               0, 0, speed));

       }
       else gameObject.transform.Rotate(new Vector3(0, 0, -speed));
      /*  if (gameObject.transform.rotation.z < -0.08f && !ok)
        {
            ok = true;
            gameObject.transform.Rotate(new Vector3(0, 0, 0.2f));
        }*/
    }
}
