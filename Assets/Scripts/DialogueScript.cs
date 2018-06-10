using UnityEngine;

public class DialogueScript : MonoBehaviour 
{
    AudioSource dialogueSource;
    Sound[] dialogueSounds;

    private void Start()
    {
        dialogueSounds = FindObjectOfType<AudioManager>().sounds;
    }

    public void PlayDialogue()
    {
        Debug.Log("audioManager - s:" + dialogueSounds.Length);

        dialogueSource = gameObject.AddComponent<AudioSource>();
        string gameObjectName = gameObject.name;
        Debug.Log("gameObjectName ::" + gameObjectName);

        setAudioProperties(gameObjectName,dialogueSource);

        if(dialogueSource.isPlaying)
        {
            return;
        }

        bool canPlayDialogue = getCanPlayDialogue(gameObjectName);

        if(canPlayDialogue)
        {
            FindObjectOfType<AudioManager>().dialogueCount++;
            FindObjectOfType<AudioManager>().Play(dialogueSource);
        }



    }

    private void setAudioProperties(string gameObjectName, AudioSource dialogueSource)
    {
        
        foreach(Sound s in dialogueSounds)
        {
            if(s.name.Equals(gameObjectName))
            {
                dialogueSource.clip = s.clip;
                dialogueSource.volume = s.volume;
                //dialogueSource.pitch = s.pitch;
                break;
            }
        }

    }

    bool getCanPlayDialogue(string gameObjectName)
    {
        int dialogueNumber = int.Parse(gameObjectName);
        if(FindObjectOfType<AudioManager>().dialogueCount == dialogueNumber)
        {
            return true;
        }
        return false;
    }
}
