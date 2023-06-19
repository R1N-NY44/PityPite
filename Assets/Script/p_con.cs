using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class p_con : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool isOnGround = true;
    public float gravityModifier = 3f;

    public GameObject nextLevelButton;
    public TextMeshProUGUI scoreText;
    private int score;

    private bool canMove = true; // Menambahkan variabel untuk mengontrol pergerakan pemain
    private AudioSource cameraAudioSource;
    private Rigidbody rb;
    private Animator playerAnim;
    private bool isWalking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        cameraAudioSource = Camera.main.GetComponent<AudioSource>(); // Mendapatkan komponen AudioSource dari kamera
        StartCoroutine(ChangeAnimationParameter());
    }

    IEnumerator ChangeAnimationParameter()
    {
        playerAnim.SetInteger("animation", 3);
        yield return new WaitForSeconds(1f);
        playerAnim.SetInteger("animation", 1);
    }

    void Update()
    {
        if (!canMove) // Tidak melakukan pergerakan jika canMove adalah false
            return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized;
        movement = movement * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 10f);
            if (!isWalking)
            {
                playerAnim.SetInteger("animation", 17);
                isWalking = true;
            }
        }
        else
        {
            if (isWalking)
            {
                playerAnim.SetInteger("animation", 1);
                isWalking = false;
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                isOnGround = true;
                break;
            }
        }
    }

    IEnumerator finishGame()
    {
        canMove = false; // Menonaktifkan pergerakan pemain
        Debug.Log("Finished");
        playerAnim.SetInteger("animation", 10);
        cameraAudioSource.Stop();
        yield return new WaitForSeconds(2.1f);
        nextLevelButton.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flag")
        {
            StartCoroutine(finishGame());     
        }

        if (other.tag == "Killzone")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Killzone");
        }

       if (other.tag == "Spikes")
        {
            canMove = false;
            Debug.Log("Spikes");
        }

        if (other.tag == "Coin")
        {
            score++;
            scoreText.text = "Score :" + score + "/3";
        }
    }

    public void NextLevel(string levelName)
    {
        if (levelName != "")
        {
            SceneManager.LoadScene(levelName);
        }
    }

    
}
