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

    [SerializeField] private QuestionUI_Test Q_UI;//测试用
    [SerializeField] private Text DialogueText;
    [SerializeField] private Text NameText;

    private GameObject player;
    private Communication communication;
    private List<string> sentences;
    private int introIndex;
    private int resultIndex;
    void Start()
    {
        UIInit();
        introIndex = 0;
        curState = TalkState.Introduce;
        player = GameObject.Find("Player");
        if (player == null) print("无Player");
        communication = player?.GetComponent<Communication>();
        Q_UI = this.GetComponent<QuestionUI_Test>();
    }

    void Update()
    {
        if (curState == TalkState.Introduce)
        {
            if (communication.Talker == null)
            {
                return;
            }

            if (Input.GetKeyUp(KeyCode.E) && !DialogueBox.activeSelf&&!communication.Talker.finished)
            {
                DialogueBox.SetActive(true);
                NameText.text = communication.Talker.NPCName;
                sentences = communication.Talker.IntroduceDialogue;
                DialogueText.text = sentences[introIndex];

                player.GetComponent<PlayerController>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }

            if (Input.GetMouseButtonDown(0) && DialogueBox.activeSelf)
            {

                if (introIndex < sentences.Count-1 )
                {
                    introIndex++;
                    DialogueText.text = sentences[introIndex];
                }
                else
                {
                    Ready.gameObject.SetActive(true);
                    Cancel.gameObject.SetActive(true);
                }
            }
        }
       else if(curState == TalkState.Result) {
            if (Q_UI.result)
            {
                sentences = communication.Talker.SuccessDialogue;
                communication.Talker.finished = true;
            }
            else
            {
                sentences = communication.Talker.FailDialogue;
            }
        DialogueText.text = sentences[resultIndex];
        if (Input.GetMouseButtonDown(0) && DialogueBox.activeSelf)
            {

                if (resultIndex < sentences.Count-1)
                {
                    print(resultIndex);
                    resultIndex++;
                    DialogueText.text = sentences[resultIndex];
                }
                else
                {
                    QuitTalking();
                }
            }
        }
    }

    public void EnterQuestion()
    {
        UIInit();
        print("开始问答");
        //打开问答界面
        QuestionEnd();//测试用代码
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
        resultIndex = 0;
        DialogueBox.SetActive(false);
        Ready.gameObject.SetActive(false);
        Cancel.gameObject.SetActive(false);
    }
}
