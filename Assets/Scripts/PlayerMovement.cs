using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform mainCamera;
    [SerializeField] Rigidbody playerRb;
    float horizontalInput;
    float verticalInput;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = getInputDirection() * speed * Time.deltaTime;
    }

    Vector3 getInputDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalInput, 0, verticalInput).normalized;
    }
}
