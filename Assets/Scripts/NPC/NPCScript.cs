using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public string NPCName = "no name";
    [SerializeReference] private TextAsset DialogueText;//装对话内容的文件可以放Dialogue里面。
    public string[] Sentences;

    void Awake()
    {
        Sentences = DialogueText.text.Split("\n");
    }

}
