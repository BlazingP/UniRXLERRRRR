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
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System.Threading;
namespace UniRxLesson
{
    public class MouseUPandDown : MonoBehaviour
    {
        void Start()
        {
            float Speed = 0;
            var mouseDownSteam = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0)).Select(_=>true);

            var mouseUpSteam = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonUp(0)).Select(_ => false);

            var isMouseUp = Observable.Merge(mouseUpSteam, mouseDownSteam);
            
            var reactiveCMD = new ReactiveCommand(isMouseUp, false);

            Observable.EveryUpdate()
               .Where(_ => Input.GetMouseButtonUp(0))
               .Subscribe(_ => { Speed = 0f; });

            reactiveCMD.Subscribe(_ =>
            {            
                Speed+=0.1f;
                Debug.LogFormat("reactive command execute{0}",Speed);
            });


            Observable.EveryUpdate()
                .Where(_=>Speed< 10f)
                .Subscribe(_ =>
                {
                    reactiveCMD.Execute();
                });
           
        }

    }
}
