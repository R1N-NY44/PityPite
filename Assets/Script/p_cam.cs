using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_cam : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Mengatur offset antara posisi kamera dan posisi pemain
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mengatur posisi kamera berdasarkan posisi pemain dengan offset
        transform.position = player.transform.position + offset;
    }
}
