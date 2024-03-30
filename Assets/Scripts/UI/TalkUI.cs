using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI : MonoBehaviour
{
    public enum TalkState:int
    {
        Introduce,Result
    }
    public TalkState curState;

    public GameObject DialogueBox;
    public Button Ready;
    public Button Cancel;
    [SerializeField] private Text DialogueText;
    [SerializeField] private Text NameText;

    private GameObject player;
    private Communication communication;
    private int index;
    void Start()
    {
        UIInit();
        curState = TalkState.Introduce;
        player = GameObject.Find("Player");
        if (player == null) print("无Player");
        communication = player?.GetComponent<Communication>();
    }

    void Update()
    {
        if (curState == TalkState.Introduce)
        {
            if (communication.Talker == null)
            {
                return;
            }

            if (Input.GetKeyUp(KeyCode.E) && !DialogueBox.activeSelf)
            {
                DialogueBox.SetActive(true);
                NameText.text = communication.Talker.NPCName;
                DialogueText.text = communication.Talker.Sentences[0];

                player.GetComponent<PlayerController>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }

            if (Input.GetMouseButtonDown(0) && DialogueBox.activeSelf)
            {

                if (index < communication.Talker.Sentences.Length-1 )
                {
                    index++;
                    DialogueText.text = communication.Talker.Sentences[index];
                }
                else
                {
                    Ready.gameObject.SetActive(true);
                    Cancel.gameObject.SetActive(true);
                }
            }
        }
    }

    public void EnterQuestion()
    {
        UIInit();
        print("开始问答");
        //打开问答界面
    }
    public void QuitTalking()
    {
        player.GetComponent<PlayerController>().enabled =true;
        curState = TalkState.Introduce;
        UIInit();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuestionEnd()
    {
        curState = TalkState.Result;
        DialogueBox.SetActive(true) ;
    }

    private void UIInit()
    {
        index = 0;
        DialogueBox.SetActive(false);
        Ready.gameObject.SetActive(false);
        Cancel.gameObject.SetActive(false);
    }
}
