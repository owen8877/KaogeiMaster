using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AiControllerGame : MonoBehaviour {
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

    public class NeckData {
        public float roll, yaw, pitch;
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
    public OtherData otherData = new OtherData();
    public NeckData neckData = new NeckData();

    bool mockup = false;

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
	
    const float alpha = 0.4f, beta = 0.4f;
    Vector3[] velocity = new Vector3[30];

	void Update () {
        updateParameter(ServerInteraction.fetchData(mockup));


        eyeBrow.eyeBrowMiddleUp.transform.localPosition = Vector3.SmoothDamp(eyeBrow.eyeBrowMiddleUp.transform.localPosition, new Vector3(0, 0, eyeBrowData.eyeBrowMiddleUp), ref velocity[0],  alpha);
        eyeBrow.eyeBrowUp.transform.localPosition  = Vector3.SmoothDamp(eyeBrow.eyeBrowUp.transform.localPosition, new Vector3(0, 0, eyeBrowData.eyeBrowUp), ref velocity[1],  alpha);
        eyeBrow.frown.transform.localPosition  = Vector3.SmoothDamp(eyeBrow.frown.transform.localPosition, new Vector3(0, 0, eyeBrowData.frown), ref velocity[2],  alpha);
        eyeBrow.angry.transform.localPosition  = Vector3.SmoothDamp(eyeBrow.angry.transform.localPosition, new Vector3(0, 0, eyeBrowData.angry), ref velocity[3],  alpha);

        eye.smileEye.transform.localPosition  = Vector3.SmoothDamp(eye.smileEye.transform.localPosition, new Vector3(0, 0, eyeData.smileEye), ref velocity[4],  alpha);
        eye.shutEye.transform.localPosition  = Vector3.SmoothDamp(eye.shutEye.transform.localPosition, new Vector3(0, 0, eyeData.shutEye), ref velocity[5],  alpha);
        eye.winkLeft.transform.localPosition  = Vector3.SmoothDamp(eye.winkLeft.transform.localPosition, new Vector3(0, 0, eyeData.winkLeft), ref velocity[6],  alpha);
        eye.winkRight.transform.localPosition  = Vector3.SmoothDamp(eye.winkRight.transform.localPosition, new Vector3(0, 0, eyeData.winkRight), ref velocity[7],  alpha);
        eye.wink2Left.transform.localPosition  = Vector3.SmoothDamp(eye.wink2Left.transform.localPosition, new Vector3(0, 0, eyeData.wink2Left), ref velocity[8],  alpha);
        eye.wink2Right.transform.localPosition  = Vector3.SmoothDamp(eye.wink2Right.transform.localPosition, new Vector3(0, 0, eyeData.wink2Right), ref velocity[9],  alpha);
        eye.hikuli.transform.localPosition  = Vector3.SmoothDamp(eye.hikuli.transform.localPosition, new Vector3(0, 0, eyeData.hikuli), ref velocity[10],  alpha);
        eye.sorrow.transform.localPosition  = Vector3.SmoothDamp(eye.sorrow.transform.localPosition, new Vector3(0, 0, eyeData.sorrow), ref velocity[11],  alpha);
        eye.despise.transform.localPosition  = Vector3.SmoothDamp(eye.despise.transform.localPosition, new Vector3(0, 0, eyeData.despise), ref velocity[12],  alpha);
        eye.doujiyan.transform.localPosition  = Vector3.SmoothDamp(eye.doujiyan.transform.localPosition, new Vector3(0, 0, eyeData.doujiyan), ref velocity[13],  alpha);

        lip_.a.transform.localPosition  = Vector3.SmoothDamp(lip_.a.transform.localPosition, new Vector3(0, 0, lipData.a), ref velocity[14],  alpha);
        lip_.i.transform.localPosition  = Vector3.SmoothDamp(lip_.i.transform.localPosition, new Vector3(0, 0, lipData.i), ref velocity[15],  alpha);
        lip_.u.transform.localPosition  = Vector3.SmoothDamp(lip_.u.transform.localPosition, new Vector3(0, 0, lipData.u), ref velocity[16],  alpha);
        lip_.e.transform.localPosition  = Vector3.SmoothDamp(lip_.e.transform.localPosition, new Vector3(0, 0, lipData.e), ref velocity[17],  alpha);
        lip_.o.transform.localPosition  = Vector3.SmoothDamp(lip_.o.transform.localPosition, new Vector3(0, 0, lipData.o), ref velocity[18],  alpha);
        lip_.oo.transform.localPosition  = Vector3.SmoothDamp(lip_.oo.transform.localPosition, new Vector3(0, 0, lipData.oo), ref velocity[19],  alpha);
        lip_.ii.transform.localPosition  = Vector3.SmoothDamp(lip_.ii.transform.localPosition, new Vector3(0, 0, lipData.ii), ref velocity[20],  alpha);
        lip_.roundMouth.transform.localPosition  = Vector3.SmoothDamp(lip_.roundMouth.transform.localPosition, new Vector3(0, 0, lipData.roundMouth), ref velocity[21],  alpha);
        lip_.triangleMouth.transform.localPosition  = Vector3.SmoothDamp(lip_.triangleMouth.transform.localPosition, new Vector3(0, 0, lipData.triangleMouth), ref velocity[22],  alpha);
        lip_.smike.transform.localPosition  = Vector3.SmoothDamp(lip_.smike.transform.localPosition, new Vector3(0, 0, lipData.smike), ref velocity[23],  alpha);
        lip_.mouthDown.transform.localPosition  = Vector3.SmoothDamp(lip_.mouthDown.transform.localPosition, new Vector3(0, 0, lipData.mouthDown), ref velocity[24],  alpha);
        lip_.surprise.transform.localPosition  = Vector3.SmoothDamp(lip_.surprise.transform.localPosition, new Vector3(0, 0, lipData.surprise), ref velocity[25],  alpha);
        lip_.cry.transform.localPosition  = Vector3.SmoothDamp(lip_.cry.transform.localPosition, new Vector3(0, 0, lipData.cry), ref velocity[26],  alpha);

        other.smallMouth.transform.localPosition  = Vector3.SmoothDamp(other.smallMouth.transform.localPosition, new Vector3(0, 0, otherData.smallMouth), ref velocity[27],  alpha);
        other.smallPupil.transform.localPosition  = Vector3.SmoothDamp(other.smallPupil.transform.localPosition, new Vector3(0, 0, otherData.smallPupil), ref velocity[28],  alpha);

        /*
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

        other.smallMouth.transform.localPosition = new Vector3(0, 0, otherData.smallMouth);
        other.smallPupil.transform.localPosition = new Vector3(0, 0, otherData.smallPupil);
        */
        neck.transform.rotation = Quaternion.Slerp(neck.transform.rotation, Quaternion.Euler(neckData.pitch, neckData.yaw, neckData.roll), beta);
	}

    void updateParameter(float[] result) {
        neckData.yaw = result[0];
        neckData.pitch = result[1];
        neckData.roll = result[2];
        eyeData.winkLeft = 1 - result[3];
        eyeData.winkRight = 1 - result[4];
        lipData.a = result[5];
    }
}
