using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    [Header("UI References")]
    public Image Portrait;
    public TMP_Text actorName;
    public TMP_Text DialogueText;
    public DialogueSO currentDialogue;
    private int dialogueIndex;
    public bool isDialogueActive;

    private void Start()
    {
        ShowDialogue();
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void ShowDialogue()
    {
        DialogueLine line = currentDialogue.lines[dialogueIndex];

        Portrait.sprite = line.speaker.portrait;
        actorName.text = line.speaker.actorName;

        DialogueText.text = line.text;
        dialogueIndex++;
    }
    public void StartDialogue()
    {
        isDialogueActive = true;
        ShowDialogue();
    }
    public void NextDialogue()
    {
        if (dialogueIndex < currentDialogue.lines.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DialogueManager.Instance.isDialogueActive)
                DialogueManager.Instance.NextDialogue();
            else
                DialogueManager.Instance.StartDialogue();
        }
    }
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialogueIndex = 0;
    }


}
