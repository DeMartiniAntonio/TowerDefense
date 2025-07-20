using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    // Napravite vrata koja su zakljucana i mogu se otkljucati samo ako igrac pokupi kljuc.
    // Nakon sto je igrac pokupio kljuc i ako je blizu vrata mora pritisnuti tipku E ( ispis na ekranu) da bi otvorio vrata. 
    [SerializeField] private int speed = 3;
    [SerializeField] private Rigidbody playerRigidbody;



    public bool gotKey = false;

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.D) && transform.position.x > -4.5f )
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -4.5f )
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.W) && transform.position.z < 4.5f)
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x < 4.5f)
        {
            Move(Vector3.right);
        }

    }
    private void Move(Vector3 direction)
    {
        direction.Normalize();
        Vector3 target = direction * speed;
        playerRigidbody.linearVelocity = Vector3.Lerp(playerRigidbody.linearVelocity, target, 300 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SphereCollider sphereCollider))
        {
            gotKey= true;
            Destroy(other.gameObject);
        }
    }

    
}
