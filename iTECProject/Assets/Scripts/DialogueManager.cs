using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour
{
    public bool IsDialogOpen { get; private set; }

    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI dialogText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public System.Action OnYesSelected;
    public System.Action OnNoSelected;

    bool isFinalResponse;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialogue dialog;
    int currentLine = 0;
    bool isTyping;
    bool isChoosing;

    public IEnumerator ShowDialog(Dialogue dialog)
    {
        IsDialogOpen = true;

        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (isChoosing)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                OnYesSelected?.Invoke();
                StartCoroutine(TypeDialog(dialog.yesResponse));

                isChoosing = false;
                isFinalResponse = true;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                OnNoSelected?.Invoke();
                StartCoroutine(TypeDialog(dialog.noResponse));

                isChoosing = false;
                isFinalResponse = true;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            if (isFinalResponse)
            {
                CloseDialog();
                isFinalResponse = false;
                return;
            }

            ++currentLine;

            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                if (dialog.hasChoice)
                {
                    dialogText.text = "Press Y = Yes / N = No";
                    isChoosing = true;
                }
                else
                {
                    CloseDialog();
                }
            }
        }
    }

    void CloseDialog()
    {
        IsDialogOpen = false;

        dialogBox.SetActive(false);
        OnHideDialog?.Invoke();

        currentLine = 0;
        isChoosing = false;
        isFinalResponse = false;

        OnYesSelected = null;
        OnNoSelected = null;
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
