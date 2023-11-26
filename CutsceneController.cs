using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public PlayerController player;
    public Animator cutsceneAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        // Disable player movement
        player.canMove = false;

        // Play the cutscene animation
        cutsceneAnimator.Play("CutsceneAnimation");

        // Wait for the length of the animation
        yield return new WaitForSeconds(cutsceneAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Enable player movement
        player.canMove = true;
    }
}