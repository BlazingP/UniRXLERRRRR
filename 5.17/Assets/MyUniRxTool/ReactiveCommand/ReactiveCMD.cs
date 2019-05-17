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
    public class ReactiveCMD : MonoBehaviour
    {
        void Start()
        {
            var reactiveCMD = new ReactiveCommand();


            reactiveCMD.Subscribe(_ =>
            {
                Debug.Log("Execute");
            });

            reactiveCMD.Execute();
            reactiveCMD.Execute();
            reactiveCMD.Execute();

        }

    }
}
