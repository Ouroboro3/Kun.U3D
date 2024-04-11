using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    public enum loadState : int
    {
        loading,waiting
    }
    public string textInput;
    public List<char> textOutput;
    public loadState curState = loadState.waiting;
    [SerializeField]private float waitTime;
    private float timer=0;
    private int count=0;
    private void Awake()
    {
        textOutput = new List<char>();
    }
    private void Update()
    {
        if(textInput==null)return;
        if (curState == loadState.loading)
        {
            if (timer >=waitTime&&count<textInput.Length)
            {
                textOutput.Add(textInput[count]);
                count++;
                timer-=waitTime;
            }
            timer += Time.deltaTime * Time.timeScale;
        }
        if (count >= textInput.Length)
        {
            curState = loadState.waiting;
        }
    }

    public void Accelerate()
    {
        OutputInit();
        count = textInput.Length;
        curState = loadState.waiting;
        textOutput.AddRange(textInput);
    }
    public void OutputInit()
    {
        textOutput.Clear();
        count = 0;
    }
    public void StartLoading(string text)
    {
        textInput = text;
        curState = loadState.loading;
        OutputInit();
    }
}
