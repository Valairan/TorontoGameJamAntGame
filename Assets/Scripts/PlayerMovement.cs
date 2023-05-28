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
    [SerializeField] GameObject pheromonePrefab;
    GameObject previousNodePheromone;
    [SerializeField] List<Transform> collectedItems;

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
        Debug.Log(ticker.pheromone);
        if((int)(ticker.pheromone * 10) % 2 == 0)
        {
            Debug.Log(ticker.pheromone);

            if (previousNodePheromone != null)
            {
                if(Vector3.Distance(previousNodePheromone.transform.position, transform.position) > 2.0f)
                {
                    previousNodePheromone = Instantiate(pheromonePrefab, transform.position, Quaternion.identity);
                }
            }
            else
            {
                previousNodePheromone = Instantiate(pheromonePrefab, transform.position, Quaternion.identity);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Food")){
            ticker.GainFood();
        }else if (collision.transform.CompareTag("Water"))
        {
            ticker.GainWater();
        }
        else if (collision.transform.CompareTag("Material"))
        {
            ticker.GainBuildingMaterials();
        }
        else if (collision.transform.CompareTag("Dew"))
        {
            ticker.GainHoneydew();
        }
    }

}
