using UnityEngine;

public class flag : MonoBehaviour
{
    public AudioClip FinishMusic;
    public float volume = 2.8f; // Volume musik (default: 0.8)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player mengenai koin!");
            AudioSource.PlayClipAtPoint(FinishMusic, transform.position, volume);
            gameObject.SetActive(false);
        }
    }
}
