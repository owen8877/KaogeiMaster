using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class rend : MonoBehaviour {
    int t = 0;
    GameObject chuyin;
    GameObject a;

	// Use this for initialization
	void Start () {
        chuyin = GameObject.Find("chuyin");
        a = GameObject.Find("chuyin/Expression/a");
        Debug.Log(a);
	}
	
	// Update is called once per frame
	void Update () {
        a.transform.localPosition = new Vector3(0, 0, Mathf.Abs(Mathf.Sin(t/20f)));
        t++;
	}
}
