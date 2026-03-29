using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialogue beforeQuestDialog;
    [SerializeField] Dialogue duringQuestDialog;
    [SerializeField] Dialogue afterQuestDialog;

    public Quest quest;

    public void Interact()
    {
        if (DialogueManager.Instance.IsDialogOpen)
            return;

        if (!quest.isActive)
        {
            DialogueManager.Instance.OnYesSelected = quest.StartQuest;
            StartCoroutine(DialogueManager.Instance.ShowDialog(beforeQuestDialog));
        }
        else if (!quest.isCompleted)
        {
            StartCoroutine(DialogueManager.Instance.ShowDialog(duringQuestDialog));
        }
        else
        {
            StartCoroutine(DialogueManager.Instance.ShowDialog(afterQuestDialog));
        }
    }
}
