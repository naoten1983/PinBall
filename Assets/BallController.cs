using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;

    //衝突相手のtagを格納する変数
    private string collisionTargetTag;

    //衝突相手のtagを格納する変数
    private float scorePoint;


    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }


    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //衝突相手のtagを取得
        this.collisionTargetTag = other.transform.tag;

        //衝突相手のtagに応じてscorePointに点数を加算
        if (this.collisionTargetTag == "LargeCloudTag")
        {
            scorePoint += 40;
        }
        else if(this.collisionTargetTag == "SmallCloudTag")
        {
            scorePoint += 30;
        }
        else if (this.collisionTargetTag == "LargeStarTag")
        {
            scorePoint += 20;
        }
        else if (this.collisionTargetTag == "SmallStarTag")
        {
            scorePoint += 10;
        }


        //ScoreTextに点数を表示
        this.scoreText.GetComponent<Text>().text = "SCORE " + scorePoint;
    }
}
