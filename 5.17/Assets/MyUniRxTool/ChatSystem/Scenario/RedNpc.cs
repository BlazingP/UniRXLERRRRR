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
    public class RedNpc : MonoBehaviour
    {
        public string  Sentences;
        private void Start()
        {

            this.OnTriggerStay2DAsObservable()
                .Where(y => y.gameObject.tag == "Player")
                .Subscribe(y =>
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                });
            this.OnTriggerExit2DAsObservable()
                .Where(y => y.gameObject.tag == "Player")
                .Subscribe(y =>
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                });
        }
    }
}
