using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        StartCoroutine(ChangeAnimationParameter());
    }

    IEnumerator ChangeAnimationParameter()
    {
        while (true)
        {
            playerAnim.SetInteger("animation", 14);
            yield return new WaitForSeconds(4f);
            playerAnim.SetInteger("animation", 10);
            yield return new WaitForSeconds(2f);
        }
    }
}
