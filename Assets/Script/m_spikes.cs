using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class m_spikes : MonoBehaviour
{
    public GameObject spikes;
    public GameObject spikesHidden;

    public AudioClip crashSound;
    public Animator playerAnimator;

    public float toggleTime = 2f;

    private bool isSpikesVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        // Memulai coroutine untuk mengatur penampilan dan penghilangan spikes
        StartCoroutine(ToggleSpikes());
    }

    // Coroutine untuk mengatur penampilan dan penghilangan spikes
    IEnumerator ToggleSpikes()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleTime);

            if (isSpikesVisible)
            {
                spikes.SetActive(false);    
                //spikesHidden.SetActive(true);
                isSpikesVisible = false;
            }
            else
            {
                spikes.SetActive(true);
                //spikesHidden.SetActive(false);
                isSpikesVisible = true;
            }
        }
    }

    // Deteksi saat pemain mengenai spikes
    private IEnumerator PlaySpikesAnimation()
    {
        playerAnimator.SetInteger("animation", 9);
        yield return new WaitForSeconds(2f);
        playerAnimator.SetInteger("animation", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isSpikesVisible && collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position);
            StartCoroutine(PlaySpikesAnimation());
        }
    }

}
