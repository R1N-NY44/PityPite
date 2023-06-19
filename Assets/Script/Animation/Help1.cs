using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help1 : MonoBehaviour
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
            playerAnim.SetInteger("animation", 10);
            yield return new WaitForSeconds(3f);
            playerAnim.SetInteger("animation", 1);
            yield return new WaitForSeconds(5f);
            playerAnim.SetInteger("animation", 12);
            yield return new WaitForSeconds(5f);
            playerAnim.SetInteger("animation", 1);
            yield return new WaitForSeconds(6f);
            playerAnim.SetInteger("animation", 3);
            yield return new WaitForSeconds(3f);
            playerAnim.SetInteger("animation", 3);
            yield return new WaitForSeconds(4f);
        }
    }
}
