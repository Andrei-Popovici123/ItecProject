using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public Quest quest;
        

    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                quest.AddItem();
                Destroy(gameObject);
            }
    }
}
