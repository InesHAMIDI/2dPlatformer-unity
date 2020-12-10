using UnityEngine;

public class Weakspot : MonoBehaviour
{
    public GameObject objetToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(objetToDestroy);
        }
    }
}
