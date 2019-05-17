//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register    登録
//　Login　　   ログイン　
//  Focus       焦点に集まる  
//  Instructio  指令　　
//  Coroutine   コルーチン
//  Thread 　　 糸　　スレッド
//  results　   結果
//  Collection 回収　　集めること
//  resource   資源　
//  request   要請する ようせい　要求する
//  progress  	進歩、発達、発展、前進、進行、成り行き、経過
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using DG.Tweening;
namespace GameProjectOne
{
    public class dialoguesystem : MonoBehaviour
    {

        GameObject Player;
        GameObject mChat;
        GameObject _GroundCheck;
        public Text mtext;
        public Camera mCamera;
        public new Rigidbody2D rigidbody2D;
        public float yForce;
        bool CanMove=true;

        public string mSentences;

        public Button Chatbutton;
        bool CanJump = false;
        bool onChat = false;
        private void Awake()
        {
            Player = GameObject.Find("Player");
            mChat = GameObject.Find("Chat");
            _GroundCheck = GameObject.Find("Player/GroundCheck");
            yForce = 5f;
        }
        //---------------------------------------------

        public bool JumpKey
        {
            get
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
        }
        //---------------------------------------------
        void Start()
        {
            var Chatbutton =GameObject.Find("Canvas/Chat/ButtonA").GetComponent<Button>();
                 mChat.SetActive(false);

                 Player.OnTriggerStay2DAsObservable()
                .Where(x => x.gameObject.tag == "Npc")
                .Where(x => Input.GetKeyDown(KeyCode.X))
                .Subscribe(x =>
                {
                    //Time.timeScale = 0
                    //x.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    mSentences = x.gameObject.GetComponent<RedNpc>().Sentences;     //targetのSentencesをゲットする
                    Chatbutton.interactable=false;   // button をクリック出来なくなる。
                    CanMove = false;
                    Debug.Log(x.gameObject);

                    mCamera.transform.DOShakePosition(1, new Vector3(1, 1, 0))
                    .OnComplete(delegate { mChat.SetActive(true); mCamera.transform.position = new Vector3(0,1,-10); });                  // 振り動かす	
                    mtext.DOText(mSentences,3f)
                    .OnComplete(delegate { onChat = true; Chatbutton.interactable = true; });  // .OnComplete(delegate {  }); 前のコマンド実行したら実行する。　複数可能

                });


            _GroundCheck.OnTriggerStay2DAsObservable()
                .Where(j => j.gameObject.tag == "Ground")
                .Subscribe(_ =>
                {
                    if (JumpKey)
                    {
                        rigidbody2D.AddForce(Vector2.up * yForce * 100);  
                    }
                });
                Observable.EveryUpdate()
                .Where(_=>onChat&&Input.GetKeyDown(KeyCode.X))   //チャットボックスを閉じる
                .Subscribe(_ =>{
                    mtext.text = "";
                    onChat = false;
                    mChat.SetActive(false);
                    CanMove = true;     
                });
                
                 Player.UpdateAsObservable()                      //Player のコントロール
                .Where(_=>CanMove)
                .Subscribe(_ =>
                {   
                   float speed = Input.GetAxisRaw("Horizontal") *5f*Time.deltaTime;
                   Player.transform.Translate(speed, 0, 0);
                });

        }
    }   
}