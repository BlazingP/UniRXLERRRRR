//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//  Focus    焦点に集まる  
//  Instructio   指令　　
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UniRxLesson
{
    public class AllButtonClickedOnce : MonoBehaviour
    {
        public GameObject mtext;
        public GameObject mtext1;
        void Start()
        {
            var left = GameObject.Find("Left");
            var right = GameObject.Find("Right");
            bool Amc = false;
            var leftMouseClickedEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).First();
            var rightMouseClickedEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).First();

            var buttonA = transform.Find("ButtonA").GetComponent<Button>();
            var buttonB = transform.Find("ButtonB").GetComponent<Button>();

            var buttonAClickedEvents = buttonB.OnClickAsObservable().First();
            var buttonBClickedEvents = buttonB.OnClickAsObservable().First();
            Observable.EveryUpdate()
                .Where(_=> !Amc)
                .Subscribe(_=>
                {
                    left.SetActive(false);
                    right.SetActive(false);
                });

            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe(_ =>
                {
                    left.SetActive(true);
                });
            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(1))
                .Subscribe(_ =>
                {
                    right.SetActive(true);
                });

            //------------------------------------------------------------------
            //　When　All 　全てのイベントを実行したら　実行する
            //------------------------------------------------------------------
            Observable.WhenAll(leftMouseClickedEvents, rightMouseClickedEvents)
                .Subscribe(_ =>
                {
                    Debug.Log("all mouse clicked !");
                    Amc = true;
                    left.SetActive(true);
                    right.SetActive(true);
                    mtext1.SetActive(true);

                });

            Observable.WhenAll(buttonAClickedEvents, buttonBClickedEvents)
                .Subscribe(_ =>
                {
                    Debug.Log("all button clicked !!");
                    buttonA.interactable = false;
                    buttonB.interactable = false;
                    mtext.SetActive(true);
                });
        }
    }
}
