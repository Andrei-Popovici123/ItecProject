using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialogue dialog;

    public void Interact()
    {
        StartCoroutine(DialogueManager.Instance.ShowDialog(dialog));
    }
}
