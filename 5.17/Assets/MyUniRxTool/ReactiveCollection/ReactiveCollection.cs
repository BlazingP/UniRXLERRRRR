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
    public class ReactiveCollection : MonoBehaviour
    {
        ReactiveCollection<string> mNames = new ReactiveCollection<string>
        {
            "My Name Is Zhu Rui Yu",
            "From China"
        };


        void Start()
        {
            foreach(var url in mNames)
            {
                Debug.Log(url);
            }
            mNames.ObserveAdd().Subscribe(addUrl => Debug.LogFormat("Add:{0}", addUrl));
            mNames.ObserveRemove().Subscribe(removeUrl => Debug.LogFormat("Remove:{0}", removeUrl));
            mNames.ObserveCountChanged().Subscribe(count => Debug.LogFormat("count:{0}", count));   //Countのチェンジを監視する。

            mNames.Add("22Years Old");
            mNames.Remove("From China");

            //ObserverMover  移動
            //ObserverReplace　　削除　

        }
    }
}