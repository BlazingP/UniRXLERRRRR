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
//  progress    進歩、発達、発展、前進、進行、成り行き、経過
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
using System.Linq;
namespace UniRxLesson
{
    public class UniRxSelect : MonoBehaviour
    {
        void Start()
        {
            //UniR（链）式代码--------------------------
            Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.X))
                .Select(_ => "X Down")              //由此可见常用的替代—其实是一个string 类型   
                .Subscribe(XEventName =>
                {
                    Debug.Log(XEventName);
                })
                .AddTo(this);
            //查询式代码--------------------------
            (from updateEvent in Observable.EveryUpdate() where Input.GetKeyDown(KeyCode.X) select "X Down1")
                .Subscribe(XEventName => Debug.Log(XEventName))
                .AddTo(this);
        }
    }
}