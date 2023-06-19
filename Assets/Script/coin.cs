using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player mengenai koin!");
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            gameObject.SetActive(false);
        }
    }
}
