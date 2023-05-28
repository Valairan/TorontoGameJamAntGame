using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform mainCamera;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Transform groundCheck;
    [SerializeField] Animator playerAnimator;
    [SerializeField] InGameUI ticker;
    [SerializeField] LineRenderer pheromoneRenderer;
    List<Vector3> listOfPoints;
    [SerializeField] List<Transform> collectedItems;

    float horizontalInput;
    float verticalInput;
    [SerializeField] float m_MovementSmoothing = 0.5f;
    Vector3 m_Velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        listOfPoints = new List<Vector3>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        playerRb.velocity =  Vector3.SmoothDamp(playerRb.velocity, getInputDirection() * speed * Time.deltaTime, ref m_Velocity, m_MovementSmoothing);
        HandleAnimation(new Vector2(getInputDirection().x, getInputDirection().z));
        DropPheromone();
    }

    Vector3 getInputDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    void HandleAnimation(Vector2 axes)
    {
        playerAnimator.SetFloat("Y", axes.y);

        playerAnimator.SetFloat("X", axes.x);
    }

    void DropPheromone()
    {
        if((ticker.pheromone * 10) % 10 == 0)
        {
            listOfPoints.Add(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Collectible")){
            collectedItems.Add(collision.transform);

        }
    }

}
