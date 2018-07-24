using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventImposeHandler : MonoBehaviour {

    int gameObjectNumber;
    DialogueScript dialogueScriptObj;
	void Start () 
    {
        gameObjectNumber = int.Parse(gameObject.name);
        dialogueScriptObj = new DialogueScript();
	}
	
	
	void Update () 
    {
        Component eventHandlerComponent = gameObject.GetComponent<EventTriggerHandler>();

        if(eventHandlerComponent == null && dialogueScriptObj.getCanPlayDialogue(gameObjectNumber))
        {
            gameObject.AddComponent<EventTriggerHandler>();
        }


        if (eventHandlerComponent != null && !dialogueScriptObj.getCanPlayDialogue(gameObjectNumber))
        {
            Destroy(eventHandlerComponent);
        }

	}
}
