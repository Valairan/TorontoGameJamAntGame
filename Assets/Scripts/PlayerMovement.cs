using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform mainCamera;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Transform groundCheck;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float m_MovementSmoothing = 0.5f;
    Vector3 m_Velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        float singleStep = speed * Time.deltaTime;
        if (Physics.Raycast(groundCheck.position, -Vector3.up, out hit, 10.0f)){
            transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.up, hit.normal, singleStep,0.0f));
        }

        playerRb.velocity =  Vector3.SmoothDamp(playerRb.velocity, getInputDirection() * speed * Time.deltaTime, ref m_Velocity, m_MovementSmoothing);
    }

    Vector3 getInputDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalInput, 0, verticalInput).normalized;
    }


}
