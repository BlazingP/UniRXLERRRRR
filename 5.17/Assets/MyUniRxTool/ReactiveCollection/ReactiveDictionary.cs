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
    public class ReactiveDictionary : MonoBehaviour {

        ReactiveDictionary<string, string> mLanguageCode = new ReactiveDictionary<string, string>
        {
            {"cn","中国語" },   //"key ","value"
            {"jp","日本語" },
            {"en","英語" }
        };
	void Start () {
            mLanguageCode.ObserveAdd().Subscribe(addedlanguage => Debug.LogFormat("Add:{0}", addedlanguage));
            mLanguageCode.ObserveRemove().Subscribe(removelanguage => Debug.LogFormat("Remove:{0}", removelanguage));
            mLanguageCode.ObserveCountChanged().Subscribe(count => Debug.LogFormat("count:{0}", count));   //Countのチェンジを監視する。

            mLanguageCode.Add("mr", "火星語");
            mLanguageCode.Remove("en");
        }
  }
}
