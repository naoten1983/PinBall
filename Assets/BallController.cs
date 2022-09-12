using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;
    private GameObject scoreText;

    //�Փˑ����tag���i�[����ϐ�
    private string collisionTargetTag;

    //�Փˑ����tag���i�[����ϐ�
    private float scorePoint;


    // Start is called before the first frame update
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        //�V�[������ScoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }


    }

    //�Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        //�Փˑ����tag���擾
        this.collisionTargetTag = other.transform.tag;

        //�Փˑ����tag�ɉ�����scorePoint�ɓ_�������Z
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


        //ScoreText�ɓ_����\��
        this.scoreText.GetComponent<Text>().text = "SCORE " + scorePoint;
    }
}
