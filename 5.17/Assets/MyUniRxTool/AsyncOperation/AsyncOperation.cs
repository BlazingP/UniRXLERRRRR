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
    public class AsyncOperation : MonoBehaviour {
        public Text mtext;
	void Start () {
            //Resources.LoadAsync<GameObject>("TestCanvas").AsAsyncOperationObservable()   
            //        .Subscribe(resourceRequest =>
            //        {
            //            Debug.Log(resourceRequest.ToString());
            //            Debug.Log(resourceRequest.asset.ToString());
            //            Instantiate(resourceRequest.asset);       
            //        });
            var progressObservable = new ScheduledNotifier<float>();　　   //プログレスバーの構成　　Progress bar 

            var mslider = transform.Find("Slider").GetComponent<Slider>();

            
            SceneManager.LoadSceneAsync(0).AsAsyncOperationObservable(progressObservable)
                .Subscribe(_ =>
                {
                    Debug.Log("load done");              //ロード完了
                });

            progressObservable
                .Subscribe(progress =>
                {
                    Debug.LogFormat("完成:{0}%", progress * 100);
                    mslider.value = progress+0.1f;
                    mtext.text = progress * 100+10 + "%";
                })
                .AddTo(this);
	}
   }
}
