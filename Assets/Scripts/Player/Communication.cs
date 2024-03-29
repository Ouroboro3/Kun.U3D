using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour
{
    public NPCScript Talker;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Talker = other?.GetComponent<NPCScript>();
            if (Talker == null) print("NPC脚本未挂载");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Talker = null;
        }
    }
}
