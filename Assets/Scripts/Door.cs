using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text text;
    private bool doorOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BoxCollider boxColider) && doorOpened==false)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement.gotKey)
            {
                //set active text
                text.text = "Press E to open the door";
                text.gameObject.SetActive(true);
            }
            else
            {
                text.text = "You need a key";
                text.gameObject.SetActive(true);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BoxCollider boxColider))
        {
            text.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (other.gameObject.TryGetComponent(out BoxCollider boxColider) && playerMovement.gotKey && doorOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(false);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                doorOpened = true;
            }

        }
    }

}
