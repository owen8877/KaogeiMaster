﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class AiController : MonoBehaviour {
    class EyeBrow {
        public GameObject eyeBrowMiddleUp, eyeBrowUp, frown, angry;
    }

    class Eye {
        public GameObject smileEye, shutEye, winkLeft, winkRight, wink2Left, wink2Right, hikuli, sorrow, despise, doujiyan;
    }

    class Lip {
        public GameObject a, i, u, e, o, oo, ii, roundMouth, triangleMouth, smike, mouthDown, surprise, cry;
    }

    class Other {
        public GameObject smallPupil, smallMouth;
    }

    public class EyeBrowData {
        public float eyeBrowMiddleUp, eyeBrowUp, frown, angry;
    }

    public class EyeData {
        public float smileEye, shutEye, winkLeft, winkRight, wink2Left, wink2Right, hikuli, sorrow, despise, doujiyan;
    }

    public class LipData {
        public float a, i, u, e, o, oo, ii, roundMouth, triangleMouth, smike, mouthDown, surprise, cry;
    }

    public class OtherData {
        public float smallPupil, smallMouth;
    }

    EyeBrow eyeBrow = new EyeBrow();
    Eye eye = new Eye();
    Lip lip_ = new Lip();
    Other other = new Other();
    GameObject chuyin;
    GameObject neck;

    public EyeBrowData eyeBrowData = new EyeBrowData();
    public EyeData eyeData = new EyeData();
    public LipData lipData = new LipData();
    public OtherData otherdata = new OtherData();
    public float roll, yaw, pitch;

    int timestamp = 0;

	void Start () {
        GameObject expression = transform.Find("Expression").gameObject;

        eyeBrow.eyeBrowMiddleUp = expression.transform.Find("eyebrowmiddleup").gameObject;
        eyeBrow.eyeBrowUp = expression.transform.Find("eyebrowup").gameObject;
        eyeBrow.frown = expression.transform.Find("frown").gameObject;
        eyeBrow.angry = expression.transform.Find("angry").gameObject;

        eye.smileEye = expression.transform.Find("smileeye").gameObject;
        eye.shutEye = expression.transform.Find("shuteye").gameObject;
        eye.winkLeft = expression.transform.Find("winkleft").gameObject;
        eye.winkRight = expression.transform.Find("winkright").gameObject;
        eye.wink2Left = expression.transform.Find("wink2left").gameObject;
        eye.wink2Right = expression.transform.Find("wink2right").gameObject;
        eye.hikuli = expression.transform.Find("hikuli").gameObject;
        eye.sorrow = expression.transform.Find("sorrow").gameObject;
        eye.despise = expression.transform.Find("despise").gameObject;
        eye.doujiyan = expression.transform.Find("doujiyan").gameObject;

        lip_.a = expression.transform.Find("a").gameObject;
        lip_.i = expression.transform.Find("i").gameObject;
        lip_.u = expression.transform.Find("u").gameObject;
        lip_.e = expression.transform.Find("e").gameObject;
        lip_.o = expression.transform.Find("o").gameObject;
        lip_.oo = expression.transform.Find("oo").gameObject;
        lip_.ii = expression.transform.Find("ii").gameObject;
        lip_.roundMouth = expression.transform.Find("roundmouth").gameObject;
        lip_.triangleMouth = expression.transform.Find("trianglemouth").gameObject;
        lip_.smike = expression.transform.Find("smike").gameObject;
        lip_.mouthDown = expression.transform.Find("mouthdown").gameObject;
        lip_.surprise = expression.transform.Find("surprise").gameObject;
        lip_.cry = expression.transform.Find("cry").gameObject;

        other.smallMouth = expression.transform.Find("smallmouth").gameObject;
        other.smallPupil = expression.transform.Find("smallpupil").gameObject;

        neck = transform.Find("Model/body/center/group/waist/upper/upper2/head").gameObject;
	}
	
	void Update () {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        clientSocket.Connect("127.0.0.1", 9999);
        NetworkStream serverStream = clientSocket.GetStream();
        byte[] inStream = new byte[1000000];
        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
        string returnData = System.Text.Encoding.ASCII.GetString(inStream);

        Debug.Log(returnData);

	    string[] numberStrings = returnData.Split();
	    float[] numbers = new float[numberStrings.Length - 1];
	    for (int i = 0; i < numbers.Length - 1; ++i)
	    {
	        numbers[i] = (float) double.Parse(numberStrings[i]);
	    }

        //timestamp++;
        //roll = 10 * Mathf.Sin(timestamp / 10f);
        //yaw = 8 * Mathf.Sin(timestamp / 8f);
        //pitch = 6 * Mathf.Sin(timestamp / 13f);
	    yaw = numbers[0];
	    pitch = numbers[1];
	    roll = numbers[2];

        eyeBrow.eyeBrowMiddleUp.transform.localPosition = new Vector3(0, 0, eyeBrowData.eyeBrowMiddleUp);
        eyeBrow.eyeBrowUp.transform.localPosition = new Vector3(0, 0, eyeBrowData.eyeBrowUp);
        eyeBrow.frown.transform.localPosition = new Vector3(0, 0, eyeBrowData.frown);
        eyeBrow.angry.transform.localPosition = new Vector3(0, 0, eyeBrowData.angry);

        eye.smileEye.transform.localPosition = new Vector3(0, 0, eyeData.smileEye);
        eye.shutEye.transform.localPosition = new Vector3(0, 0, eyeData.shutEye);
        eye.winkLeft.transform.localPosition = new Vector3(0, 0, eyeData.winkLeft);
        eye.winkRight.transform.localPosition = new Vector3(0, 0, eyeData.winkRight);
        eye.wink2Left.transform.localPosition = new Vector3(0, 0, eyeData.wink2Left);
        eye.wink2Right.transform.localPosition = new Vector3(0, 0, eyeData.wink2Right);
        eye.hikuli.transform.localPosition = new Vector3(0, 0, eyeData.hikuli);
        eye.sorrow.transform.localPosition = new Vector3(0, 0, eyeData.sorrow);
        eye.despise.transform.localPosition = new Vector3(0, 0, eyeData.despise);
        eye.doujiyan.transform.localPosition = new Vector3(0, 0, eyeData.doujiyan);

        lip_.a.transform.localPosition = new Vector3(0, 0, lipData.a);
        lip_.i.transform.localPosition = new Vector3(0, 0, lipData.i);
        lip_.u.transform.localPosition = new Vector3(0, 0, lipData.u);
        lip_.e.transform.localPosition = new Vector3(0, 0, lipData.e);
        lip_.o.transform.localPosition = new Vector3(0, 0, lipData.o);
        lip_.oo.transform.localPosition = new Vector3(0, 0, lipData.oo);
        lip_.ii.transform.localPosition = new Vector3(0, 0, lipData.ii);
        lip_.roundMouth.transform.localPosition = new Vector3(0, 0, lipData.roundMouth);
        lip_.triangleMouth.transform.localPosition = new Vector3(0, 0, lipData.triangleMouth);
        lip_.smike.transform.localPosition = new Vector3(0, 0, lipData.smike);
        lip_.mouthDown.transform.localPosition = new Vector3(0, 0, lipData.mouthDown);
        lip_.surprise.transform.localPosition = new Vector3(0, 0, lipData.surprise);
        lip_.cry.transform.localPosition = new Vector3(0, 0, lipData.cry);

        other.smallMouth.transform.localPosition = new Vector3(0, 0, otherdata.smallMouth);
        other.smallPupil.transform.localPosition = new Vector3(0, 0, otherdata.smallPupil);

        neck.transform.rotation = Quaternion.Euler(-pitch, -yaw, -roll);
	    eyeData.winkLeft = 1 - numbers[3];
	    eyeData.winkRight = 1 - numbers[4];
	    lipData.a = numbers[5];
	}
}
