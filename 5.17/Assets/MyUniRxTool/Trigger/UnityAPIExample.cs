//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//  Focus    焦点に集まる  
// APIに関して　もっと詳しくは　　ObservableTriggerExtensions.cs     ObservableTriggerExtensions.Component.cs 
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxLesson
{
    public class UnityAPIExample : MonoBehaviour
    {　
        public Camera camera;
        void Start()
        {


            Observable.EveryUpdate()
                .Subscribe(_ =>
                { Debug.LogFormat("EveryUpdate{0}",this.gameObject.name); }).AddTo(this);   //　AddTo(this) 　　命をthisと関連する。thisがDestroyされると共にDestroyします　 MissingReferenceExceptionを防ぐために

            //this.UpdateAsObservable()
            //    .Subscribe(_ =>
            //    { Debug.LogFormat("EveryUpdate{0}", this.gameObject.name); });            //ADDTOと　同じ効果ですが　使うには UniRx.Triggers;が必要です
            /*------------------------------------------------------------------------*/
            //  this.OnCollisionEnter2DAsObservableなど衝突Trigger
            //  this.OnEnableAsObservable     Enable　　停止渲染
            //  this.OnDestroyAsObservable    Destroy  
            /*------------------------------------------------------------------------*/
            Observable.EveryFixedUpdate()
                .Subscribe(_ =>
                { Debug.Log("EveryFixedUpdate"); });

            Observable.EveryEndOfFrame()
                .Subscribe(_ =>
                { Debug.Log("EveryEndOfFrame"); });

            Observable.EveryLateUpdate()
                .Subscribe(_ =>
                { Debug.Log("EveryLateUpdate"); });

            Observable.EveryAfterUpdate()
                .Subscribe(_ =>
                { Debug.Log("EveryAfterUpdate"); });



            Observable.EveryApplicationFocus()  //マウスのクリックの位置はAPP上の場合TRUE　Else False
                .Subscribe(focus =>
                {
                    Debug.Log(focus);
                });

            //Observable.EveryApplicationPause() //pau
            //    .Subscribe(Paused =>
            //    {
            //        Debug.Log(Paused);
            //    });

            //Observable.EveryUpdate()
            //    .Where(_ => Input.GetKeyDown(KeyCode.Space))
            //    .Subscribe(_ =>
            //    {
            //        if (Time.timeScale == 0)
            //        {   
            //            Time.timeScale = 1;
            //            Debug.LogFormat("Pased?{0}", Time.timeScale);
            //        }
            //        else { Time.timeScale = 0;
            //            Debug.LogFormat("Pased?{0}", Time.timeScale);
            //        }
            //    });

            this.OnDestroyAsObservable()                 //thisがDestroyされたら実行する
                .Subscribe(_ =>
                {
                    Debug.Log("On destroyed");
                    camera.backgroundColor = Color.red;
                });        
           
        }
    }
}
