using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBehaviour : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialoguePanel;

    public CharacterStateData playerState;

    private DialogueData currentDialogue;
    private int currentLineIndex;

    public void StartDialogue(DialogueData dialogue)
    {
        dialoguePanel.SetActive(true);
        playerState.currentState = CharacterStateData.States.Stopped;
        
        currentDialogue = dialogue;
        currentLineIndex = 0;
        
        currentDialogue.onDialogueStart.Invoke();
        
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex >= currentDialogue.lines.Count)
        {
            CloseDialogue();
            return;
        };
        
        var currentLine = currentDialogue.lines[currentLineIndex];

        nameText.text = currentLine.character.characterName;
        dialogueText.text = currentLine.text;
        
        currentLine.character.Raise();
        currentLine.lineData.lineEvent.Invoke();
        
        
        currentLineIndex++;
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        playerState.currentState = CharacterStateData.States.Walking;
    }
}
