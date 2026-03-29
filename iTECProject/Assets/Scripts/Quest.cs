using UnityEngine;

public class Quest : MonoBehaviour
{
    public int requiredItems = 3;
    public int currentItems = 0;

    public bool isActive;
    public bool isCompleted;

    public void StartQuest()
    {
        isActive = true;
        Debug.Log("Quest started");
    }

    public void AddItem()
    {
        if (!isActive) return;

        currentItems++;

        if (currentItems >= requiredItems)
        {
            isCompleted = true;
            Debug.Log("Quest completed!");
        }
    }
}
    