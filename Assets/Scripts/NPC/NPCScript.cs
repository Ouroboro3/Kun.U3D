using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public int Num;
    public string NPCName = "no name";
    public int textIndex = 0;
    public bool finished;
    [SerializeReference] private TextAsset DialogueText;//装对话内容的文件可以放Dialogue里面。
    public List<string> IntroduceDialogue;
    public List<string> SuccessDialogue;
    public List<string> FailDialogue;

    void Awake()
    {
        string[] parts = DialogueText.text.Split("#");
        foreach (string ele in parts[0].Split("\n"))
        {
            if (ele.Length > 1)
            {
                IntroduceDialogue.Add(ele);
            }

        }
        if(parts.Length<2) return ;
        foreach (string ele in parts[1].Split("\n"))
        {
            if (ele.Length>1)
            {
                SuccessDialogue.Add(ele);
            }
        }
        if(parts.Length<3) return ;
        foreach (string ele in parts[2].Split("\n"))
        {
            if (ele.Length > 1)
            {
                FailDialogue.Add(ele);
            }
        }
    }

}
