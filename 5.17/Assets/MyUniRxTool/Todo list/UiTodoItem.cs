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
namespace UniRxLesson
{
    public class UiTodoItem : MonoBehaviour
    {
        Text mContent;

        Button mBtnCompleted;

        TodoItem Model;
        void Awake()
        {
            mContent = transform.Find("Content").GetComponent<Text>();
            mBtnCompleted = transform.Find("BtnComplete").GetComponent<Button>();
            mBtnCompleted.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Model.Completed.Value = true;
                });
        }
        public void setModel(TodoItem model)
        {
            Model = model;
            UpdateView();  //diaoyong
        }
        void UpdateView()
        {
            mContent.text = Model.Content.Value;
        }
    }
}
