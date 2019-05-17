using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class RichFont : MonoBehaviour
{
    public float letterPause = 1f;
    string word;
    private Text text;


   // var new word = regex.Replace(source, "");

    void Start()    
    {
        var match = Regex.Match(word, @"<(.+).*>.*<\/\1>");

        //Regex reg = new Regex(@"<(.+).*>.*<\/\1>");
        //  string n = word.Replace(@"<(.+).*>.*<\/\1>", " ");
        Regex regEx = new Regex(@"<(.+).*>.*<\/\1>");
        word = "この文章を<color=red>一文字づつ</color>表示してください\n" +
        "途中で<b><color=blue>スペース</color></b>を押された場合は<color=yellow>一気に</color>最後まで表示してください\n" +
        "最後まで表示された後で<b><color=blue>スペース</color></b>を押されたらまた最初から表示してください";
        text = GetComponent<Text>();
        text.text = "";
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (var letter in word.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
     bool Outputcomplete=false;
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!Outputcomplete)
        {
            Outputcomplete = true;
            Debug.Log("123");
            StopAllCoroutines();
            text.text = "この文章を<color=red>一文字づつ</color>表示してください\n" +
        "途中で<b><color=blue>スペース</color></b>を押された場合は<color=yellow>一気に</color>最後まで表示してください\n" +
        "最後まで表示された後で<b><color=blue>スペース</color></b>を押されたらまた最初から表示してください";
        }
        else if(Input.GetKeyDown(KeyCode.Space) && Outputcomplete){ SceneManager.LoadScene(0);};
    }
}
