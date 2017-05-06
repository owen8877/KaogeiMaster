using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

  
public class GameJudge : MonoBehaviour {
    public GameObject lifeGameObject, scoreGameObject;
    GameObject lifeMask, scoreMask;
    public GameObject TopCard, MidCard, BottomCard;
    public GameObject aiJiang;
    public RawImage RankingImage;
    float life, score;
    bool onGoing = false;
    const float MAX_LIFE = 100, MAX_SCORE = 100;

    void Start() {
        lifeMask = lifeGameObject.transform.Find("lifeMask").gameObject;
        scoreMask = scoreGameObject.transform.Find("scoreMask").gameObject;

        reset();
    }

    const int BAR_HEIGHT = 450;

    void showLife(float _life) {
        lifeMask.transform.localPosition = new Vector3(0, Mathf.Min(- (1 - _life / MAX_LIFE) * BAR_HEIGHT, 0), 0);
    }

    void showScore(float _score) {
        scoreMask.transform.localPosition = new Vector3(0, Mathf.Min(- (1 - _score / MAX_SCORE) * BAR_HEIGHT, 0), 0);
    }

    Vector2 topVelocity = Vector2.zero, midVelocity = Vector2.zero, bottomVelocity = Vector2.zero;
    const float GOOD_SCORE = 80;
    float[] INTERVAL = {2, 4, 4, 2, 1, 2, 3, 2, 1, 4, 3, 2};
    const float MAX = 13;
    const float beta = 0.2f;
    const float offset = 0.005f;
    void updateTargetImagePosition(int _round) {
        _round = -_round;
        Vector2 topOffset = new Vector2(0, (_round) / MAX + offset);
        Material topMaterial = TopCard.GetComponent<Renderer>().material;
        Vector2 originalTop = topMaterial.GetTextureOffset("_MainTex");
        topMaterial.SetTextureOffset("_MainTex", Vector2.SmoothDamp(originalTop, topOffset, ref topVelocity, beta, 10f, Time.deltaTime));
        Vector2 midOffset = new Vector2(0, (_round + 1) / MAX + offset);
        Material midMaterial = MidCard.GetComponent<Renderer>().material;
        Vector2 originalMid = midMaterial.GetTextureOffset("_MainTex");
        midMaterial.SetTextureOffset("_MainTex", Vector2.SmoothDamp(originalMid, midOffset, ref midVelocity, beta, 10f, Time.deltaTime));
        Vector2 bottomOffset = new Vector2(0, (_round + 2) / MAX + offset);
        Material bottomMaterial = BottomCard.GetComponent<Renderer>().material;
        Vector2 originalBottom = bottomMaterial.GetTextureOffset("_MainTex");
        bottomMaterial.SetTextureOffset("_MainTex", Vector2.SmoothDamp(originalBottom, bottomOffset, ref bottomVelocity, beta, 10f, Time.deltaTime));
    }

    List<float> scoreList = new List<float>();
    float nextJudgeTime;
    int round = 0;

    void Update() {
        if (!onGoing)
            return;

        if (Time.time > nextJudgeTime) {
            judge();
            round++;
            if (round >= MAX - 1) {
                onGoing = false;
            } else {
                nextJudgeTime = Time.time + INTERVAL[round];
            }
        }

        showLife(life);
        showScore(score);
        updateTargetImagePosition(round);
        takeDownScore();
    }

    void takeDownScore() {
        // magicScore comes from eyeData, eyeBrowData, lipData, otherData
        AiControllerGame aiControllerGame = aiJiang.GetComponent<AiControllerGame>();
        AiControllerGame.EyeData eyeData = aiControllerGame.eyeData;
        AiControllerGame.EyeBrowData eyeBrowData = aiControllerGame.eyeBrowData;
        AiControllerGame.LipData lipData = aiControllerGame.lipData;
        AiControllerGame.OtherData otherData = aiControllerGame.otherData;
        AiControllerGame.NeckData neckData = aiControllerGame.neckData;
        float magicScore = 0;
        scoreList.Add(magicScore);
    }

    float calculateScore() {
        // use scoreList and round
        scoreList.Clear();
        return 85;
    }

    void judge() {
        //Debug.Log("ha!");
        float thisScore = calculateScore();
        if (thisScore > GOOD_SCORE) {
            score += 20;
        } else {
            life -= 20;
        }
    }

    public void realStart() {
        reset();
        onGoing = true;
        nextJudgeTime = Time.time + INTERVAL[0];
    }

    public void reset() {
        life = 100;
        round = 0;
        score = 0;
        onGoing = false;
    }

    void showRanking(int ranking) {
        
    }
}