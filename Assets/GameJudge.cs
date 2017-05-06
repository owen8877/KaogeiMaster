using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

  
public class GameJudge : MonoBehaviour {
    public GameObject lifeGameObject, scoreGameObject;
    GameObject lifeMask, scoreMask;
    public GameObject TopCard, MidCard, BottomCard;
    public GameObject aiJiang;
    public RawImage RankingImage;
    public GameObject gameOver;
    float life, score;
    bool onGoing = false;
    const float MAX_LIFE = 100, MAX_SCORE = 100;

    AiControllerGame aiControllerGame;
    AiControllerGame.EyeData eyeData;
    AiControllerGame.EyeBrowData eyeBrowData;
    AiControllerGame.LipData lipData;
    AiControllerGame.OtherData otherData;
    AiControllerGame.NeckData neckData;

    void Start() {
        lifeMask = lifeGameObject.transform.Find("lifeMask").gameObject;
        scoreMask = scoreGameObject.transform.Find("scoreMask").gameObject;

        reset();

        aiControllerGame = aiJiang.GetComponent<AiControllerGame>();
        eyeData = aiControllerGame.eyeData;
        eyeBrowData = aiControllerGame.eyeBrowData;
        lipData = aiControllerGame.lipData;
        otherData = aiControllerGame.otherData;
        neckData = aiControllerGame.neckData;
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
            Ranking ranking = judge();
            round++;
            setRanking(ranking);
            updateRanking(true);
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
        updateRanking(false);

        if (life < 0) {
            onGoing = false;
            updateGameOver(true);
        }
    }

    void takeDownScore() {
        // magicScore comes from eyeData, eyeBrowData, lipData, otherData
        float magicScore = 100 * Random.value;
        scoreList.Add(magicScore);
    }

    float calculateScore() {
        // use scoreList and round
        float sum = 0;
        foreach (float f in scoreList)
            sum += f;

        float result = sum / scoreList.Count;
        scoreList.Clear();
        return result;
    }

    Ranking judge() {
        //Debug.Log("ha!");
        float thisScore = 10 * Mathf.Sqrt(calculateScore());
        Debug.Log(thisScore);
 
        if (thisScore > GOOD_SCORE) {
            score += 20;
            life += 10;
        } else {
            life -= 10;
        }

        if (thisScore > 90)
            return Ranking.SS;
        if (thisScore > 80)
            return Ranking.S;
        if (thisScore > 70)
            return Ranking.A;
        if (thisScore > 60)
            return Ranking.B;
        if (thisScore > 50)
            return Ranking.C;
        return Ranking.D;
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
        updateGameOver(false);
    }

    enum Ranking {
        SS, S, A, B, C, D
    };

    void setRanking(Ranking ranking) {
        Vector2 xy = Vector2.zero, offset = Vector2.zero;
        switch (ranking) {
            case Ranking.A:
                xy = new Vector2(0f, 0.5f);
                offset = new Vector2(0.33f, 0.5f);
                break;
            case Ranking.B:
                xy = new Vector2(0.34f, 0.5f);
                offset = new Vector2(0.33f, 0.5f);
                break;
            case Ranking.C:
                xy = new Vector2(0.66f, 0.5f);
                offset = new Vector2(0.33f, 0.5f);
                break;
            case Ranking.D:
                xy = new Vector2(0f, 0f);
                offset = new Vector2(0.33f, 0.5f);
                break;
            case Ranking.S:
                xy = new Vector2(0.32f, 0f);
                offset = new Vector2(0.33f, 0.5f);
                break;
            case Ranking.SS:
                xy = new Vector2(0.66f, 0f);
                offset = new Vector2(0.33f, 0.5f);
                break;
        }
        RankingImage.uvRect = new Rect(xy[0], xy[1], offset[0], offset[1]);
    }

    void updateRanking(bool force) {
        float gamma = 0.03f;
        if (force)
            RankingImage.color = new Vector4(RankingImage.color.r, RankingImage.color.g, RankingImage.color.b, 1);
        else
            RankingImage.color = new Vector4(RankingImage.color.r, RankingImage.color.g, RankingImage.color.b, RankingImage.color.a * (1 - gamma));
        //Debug.Log(RankingImage.color.a);
    }

    void updateGameOver(bool over) {
        if (over)
            gameOver.GetComponent<Text>().color = new Vector4(199/256f, 15/256f, 15/256f, 255/256f);
        else
            gameOver.GetComponent<Text>().color = new Vector4(199/256f, 15/256f, 15/256f, 0f);
    }
}