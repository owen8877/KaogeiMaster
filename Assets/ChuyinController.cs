using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChuyinController : MonoBehaviour {
    class EyeBrow {
        public GameObject serious, sadness, cheerful, anger, goUp, goDown;
    }

    class Eye {
        public GameObject blink, closeMeng, smile, wink;
    }

    class Lip {
        public GameObject a, i, u, o, grin;
    }

    public class EyeBrowData {
        public float serious, sadness, cheerful, anger, goUp, goDown;
    }

    public class EyeData {
        public float blink, closeMeng, smile, wink;
    }

    public class LipData {
        public float a, i, u, o, grin;
    }

    EyeBrow eyeBrow = new EyeBrow();
    Eye eye = new Eye();
    Lip lip_ = new Lip();
    GameObject chuyin;
    GameObject neck;

    public EyeBrowData eyeBrowData = new EyeBrowData();
    public EyeData eyeData = new EyeData();
    public LipData lipData = new LipData();
    public float roll, yaw, pitch;

    int timestamp = 0;

	void Start () {
        GameObject expression = transform.Find("Expression").gameObject;

        eyeBrow.serious = expression.transform.Find("serious").gameObject;
        eyeBrow.sadness = expression.transform.Find("sadness").gameObject;
        eyeBrow.cheerful = expression.transform.Find("cheerful").gameObject;
        eyeBrow.anger = expression.transform.Find("anger").gameObject;
        eyeBrow.goUp = expression.transform.Find("go up").gameObject;
        eyeBrow.goDown = expression.transform.Find("go down").gameObject;

        eye.blink = expression.transform.Find("blink").gameObject;
        eye.closeMeng = expression.transform.Find("close_meng").gameObject;
        eye.smile = expression.transform.Find("smile").gameObject;
        eye.wink = expression.transform.Find("wink").gameObject;

        lip_.a = expression.transform.Find("a").gameObject;
        lip_.i = expression.transform.Find("i").gameObject;
        lip_.u = expression.transform.Find("u").gameObject;
        lip_.o = expression.transform.Find("o").gameObject;
        lip_.grin = expression.transform.Find("wink").gameObject;

        neck = transform.Find("Model/center/upper body/neck").gameObject;
	}
	
	void Update () {
        timestamp++;
        //roll = 10 * Mathf.Sin(timestamp / 10f);
        //yaw = 8 * Mathf.Sin(timestamp / 8f);
        //pitch = 6 * Mathf.Sin(timestamp / 13f);

        eyeBrow.serious.transform.localPosition = new Vector3(0, 0, eyeBrowData.serious);
        eyeBrow.sadness.transform.localPosition = new Vector3(0, 0, eyeBrowData.sadness);
        eyeBrow.cheerful.transform.localPosition = new Vector3(0, 0, eyeBrowData.cheerful);
        eyeBrow.anger.transform.localPosition = new Vector3(0, 0, eyeBrowData.anger);
        eyeBrow.goUp.transform.localPosition = new Vector3(0, 0, eyeBrowData.goUp);
        eyeBrow.goDown.transform.localPosition = new Vector3(0, 0, eyeBrowData.goDown);

        eye.blink.transform.localPosition = new Vector3(0, 0, eyeData.blink);
        eye.closeMeng.transform.localPosition = new Vector3(0, 0, eyeData.closeMeng);
        eye.smile.transform.localPosition = new Vector3(0, 0, eyeData.smile);
        eye.wink.transform.localPosition = new Vector3(0, 0, eyeData.wink);

        lip_.a.transform.localPosition = new Vector3(0, 0, lipData.a);
        lip_.i.transform.localPosition = new Vector3(0, 0, lipData.i);
        lip_.u.transform.localPosition = new Vector3(0, 0, lipData.u);
        lip_.o.transform.localPosition = new Vector3(0, 0, lipData.o);
        lip_.grin.transform.localPosition = new Vector3(0, 0, lipData.grin);

        neck.transform.rotation = Quaternion.Euler(roll, yaw, pitch);
	}
}
