using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI : MonoBehaviour
{
    public GameObject DialogueBox;
    [SerializeField] private Text DialogueText;
    [SerializeField] private Text NameText;
    private Communication communication;
    private int index;
    void Start()
    {
        DialogueBox.SetActive(true);
        GameObject player = GameObject.Find("Player");
        if (player == null) print("无Player");
        communication = player?.GetComponent<Communication>();
    }

    void Update()
    {
        if (communication.Talker == null)
        {
            if(DialogueBox.activeSelf) DialogueBox.SetActive(false);
            return;
        }
 
        if (Input.GetKeyUp(KeyCode.E) && !DialogueBox.activeSelf)
        {
            DialogueBox.SetActive(true);
            NameText.text = communication.Talker.NPCName;
            DialogueText.text = communication.Talker.Sentences[0];
        }
        else if (Input.GetKeyUp(KeyCode.E) && DialogueBox.activeSelf)
        {
            index = 0;
            DialogueBox.SetActive(false) ;
        }

        if(Input.GetMouseButtonDown(0)&& DialogueBox.activeSelf)
        {

            if (index < communication.Talker.Sentences.Length - 1) index++;
            DialogueText.text = communication.Talker.Sentences[index];
        }

    }
}
