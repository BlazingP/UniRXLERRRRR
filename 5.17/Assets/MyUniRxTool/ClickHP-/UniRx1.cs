//---------------------------------------------------------------
//　
//　Subscribe  申し込む
//　Observable　観察可能な　　
//
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
    //C
    public class UniRx1 : MonoBehaviour
    {
        EnemyModel mEnemy = new EnemyModel(200);
        void Start()
        {
            var attackBtn = transform.Find("Button").GetComponent<Button>();
            var HPText = transform.Find("Text").GetComponent<Text>();

            //var Space = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space));
            
            attackBtn.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    mEnemy.HP.Value -= 20;　
                });
           
            mEnemy.HP
                .SubscribeToText(HPText);            //HPの変化があれば直ぐHPTEXTに更新する。
            mEnemy.IsDead
                .Where(IsDead=>IsDead)                // 条件があれば続く　　　IsDead=true;
                .Select(IsDead=>!IsDead)
                .SubscribeToInteractable(attackBtn);　//  Buttonをクリック出来なくなる。
        }

    }
    //M
    public class EnemyModel
    {
        public ReactiveProperty<long> HP;

        public IReadOnlyReactiveProperty <bool> IsDead;   // ReadOnly 
        
        public EnemyModel(long initialHP)
        {
            HP = new ReactiveProperty<long>(initialHP);    
            IsDead= HP.Select(hp => hp <= 0).ToReactiveProperty();  //HPがゼロまで減ると　
        }
    }
}
