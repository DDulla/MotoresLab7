using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactionMessage;
    [SerializeField] private float messageDuration = 2f;
    [SerializeField] private Rigidbody npcRigidbody;
    [SerializeField] private NPCMovement npcMovement; 

    private bool playerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && playerNearby)
        {
            StartCoroutine(ShowInteractionMessage());
        }
    }

    private IEnumerator ShowInteractionMessage()
    {
        npcMovement.StopMovement(); 
        npcRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        interactionMessage.SetActive(true);

        yield return new WaitForSeconds(messageDuration);

        interactionMessage.SetActive(false);
        npcRigidbody.constraints = RigidbodyConstraints.None;
        npcMovement.ResumeMovement(); 
    }
}