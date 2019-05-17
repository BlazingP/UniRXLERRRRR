using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class TestDoText : MonoBehaviour
{
    public Text m_text;
    public Text mtextfaker;
    void Start()
    {
     
        m_text.DOText("この文章を<color=red>一文字づつ</color>表示してください\n" +
    "途中で<b><color=blue>スペース</color></b>を押された場合は<color=yellow>一気に</color>最後まで表示してください\n" +
    "最後まで表示された後で<b><color=blue>スペース</color></b>を押されたらまた最初から表示してください。\n<color=yellow>2Gf-05 zhuruiyu</color>", 10f);
    }
    bool re = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!re)
        {
          
            mtextfaker.text = "この文章を<color=red>一文字づつ</color>表示してください\n" +
    "途中で<b><color=blue>スペース</color></b>を押された場合は<color=yellow>一気に</color>最後まで表示してください\n" +
    "最後まで表示された後で<b><color=blue>スペース</color></b>を押されたらまた最初から表示してください。\n<color=green>2Gf-05 zhuruiyu</color>";
            re = true;
        }

         else if (re&&Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        };
    }
}
