using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Cheer = false;
    [SerializeField] Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void TriggerCheer()
    {
        animator.SetTrigger("Cheer");
    }
}
