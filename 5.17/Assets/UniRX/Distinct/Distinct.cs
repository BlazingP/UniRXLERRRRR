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
//  distinct     清晰的  不同的
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
    public class Distinct : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            var bakatomos = new List<string>
            {
                "RNG",
                "IG",
                "IG"
            };
            bakatomos.Distinct()   //Distinct 操作符 只会输出不同的 重复的部分全部忽略
                .ToList()
                .ForEach(bakatomo => Debug.Log(bakatomo));


            //------- 查询式---------
            var distinctNames = (from bakatomo in bakatomos select bakatomo)
                .Distinct();
            foreach (var distinctName in distinctNames)
            {
                Debug.Log(distinctName);
            }
        }


    }
}