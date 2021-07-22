using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eagle : MonoBehaviour {

    public Sprite[] eagle;
    private Sprite sprite;
    public int frame = 10;
    public float timer = 0;
    public Image eag;

	void Start () {
        
	}
	
	
	void Update () {
        timer += Time.deltaTime;
        int frameIndex = (int)(timer * frame );
       // print(frameIndex);
        if (frameIndex >=30) timer = 0;
        eag.sprite = eagle[frameIndex];
	}
}
