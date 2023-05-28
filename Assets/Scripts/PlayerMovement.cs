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
    [SerializeField] MainMenu menu;
    [SerializeField] GameObject pheromonePrefab;
    GameObject previousNodePheromone;
    public List<GameObject> collectedItems;
    int numberOfCollectedItems = 0;

    private float timer = 2f;
    private float elapsedTime = 0f;

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
        if (menu.gameHasStarted)
        {
            playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, getInputDirection() * speed * Time.deltaTime, ref m_Velocity, m_MovementSmoothing);
            HandleAnimation(new Vector2(getInputDirection().x, getInputDirection().z));
            DropPheromone();
        }

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
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timer)
        {
            if (previousNodePheromone != null)
            {
                if (Vector3.Distance(previousNodePheromone.transform.position, transform.position) > 2.0f)
                {
                    previousNodePheromone = Instantiate(pheromonePrefab, transform.position, Quaternion.identity);
                }
            }
            else
            {
                previousNodePheromone = Instantiate(pheromonePrefab, transform.position, Quaternion.identity);

            }
            elapsedTime = 0f;
        }



        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Food"))
        {
            numberOfCollectedItems++;
            ticker.GainFood();
            collectedItems.Add(collision.gameObject);
            collision.transform.position = new Vector3(0, -25, 0);
        }else if (collision.transform.CompareTag("Water"))
        {
            numberOfCollectedItems++;
            ticker.GainWater();
            collectedItems.Add(collision.gameObject);
            collision.transform.position = new Vector3(0, -25, 0);
        }
        else if (collision.transform.CompareTag("Material"))
        {
            numberOfCollectedItems++;
            ticker.GainBuildingMaterials();
            collectedItems.Add(collision.gameObject);
            collision.transform.position = new Vector3(0, -25, 0);
        }
        else if (collision.transform.CompareTag("Dew"))
        {
            numberOfCollectedItems++;
            ticker.GainHoneydew();
            collectedItems.Add(collision.gameObject);
            collision.transform.position = new Vector3(0, -25, 0);
        }
    }

}
