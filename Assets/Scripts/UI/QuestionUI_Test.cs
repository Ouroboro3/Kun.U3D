using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUI_Test : MonoBehaviour
{
    public bool result = false;
    public TalkUI talk;
    private void Start()
    {
        talk = GetComponent<TalkUI>();
    }

    public void Right()
    {
        result = true;
        talk.QuestionBox.SetActive(false);
    }
}
