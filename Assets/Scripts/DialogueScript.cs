using UnityEngine;

public class DialogueScript : MonoBehaviour 
{

    void Start()
    {
       
    }

    public void loadDialogueOntoGO(GameObject gameObject)
    {
        Component gameObjectAudioSourceComponent = gameObject.GetComponent<AudioSource>();

        if (gameObjectAudioSourceComponent != null)
        {
            return;
        }

        AudioSource dialogueSource = gameObject.AddComponent<AudioSource>();
        string gameObjectName = gameObject.name;

        setAudioProperties(gameObjectName, dialogueSource);

    }

    public void playDialogueOfGO(GameObject gameObject)
    {
        AudioSource dialogueSource = gameObject.GetComponent<AudioSource>();

        if(dialogueSource == null)
        {
            Debug.Log("audio source not set for GO");
            return;
        }

        if(dialogueSource.isPlaying)
        {
            return;
        }

        bool canPlayDialogue = getCanPlayDialogue(int.Parse(gameObject.name));

        if(canPlayDialogue)
        {
            AudioManager.dialogueCount++;
            dialogueSource.Play();
        }

    }

    void setAudioProperties(string gameObjectName, AudioSource dialogueSource)
    {
        
        foreach(Sound s in FindObjectOfType<AudioManager>().sounds)
        {
            if(s.name.Equals(gameObjectName))
            {
                dialogueSource.clip = s.clip;
                dialogueSource.volume = s.volume;
                dialogueSource.loop = s.loop;
                break;
            }
        }

    }

    public bool getCanPlayDialogue(int dialogueNumber)
    {
        if(AudioManager.dialogueCount.Equals(dialogueNumber))
        {
            return true;
        }
        return false;
    }
}
