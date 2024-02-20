using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTimeline : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();


    }

    public void DisableThis() {
        anim.SetTrigger("fadeout");
        Invoke("DisableObj", 2);
    }

    private void DisableObj()
    {
        this.gameObject.SetActive(false);
    }
}
