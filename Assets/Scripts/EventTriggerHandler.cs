using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerHandler : EventTrigger
{
    DialogueScript dialogueScriptObj;
	void Start () 
    {
        dialogueScriptObj = new DialogueScript();
	}

	void Update ()
    {
       
	}

    public override void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("OnPointerEnter called.");
        dialogueScriptObj.loadDialogueOntoGO(gameObject);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        Debug.Log("OnPointerExit called.");
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Debug.Log("OnPointerClick called.");
        dialogueScriptObj.playDialogueOfGO(gameObject);

    }


}
