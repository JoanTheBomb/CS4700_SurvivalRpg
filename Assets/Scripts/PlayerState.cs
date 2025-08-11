using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; set; }

    // --- Player Health --- //
    public float currentHealth;
    public float maxHealth;

    // --- Player Calories --- //
    public float currentCalories;
    public float maxCalories;

    float distanceTraveled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    // --- Player Hydration --- //
    public float currentHydrationPercent;
    public float maxHydrationPercent;

    public bool isHydrationActive;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;
        currentHydrationPercent = maxHydrationPercent;

        StartCoroutine(decreaseHydration());
    }
    
    IEnumerator decreaseHydration()
    {
        while (true)
        {
            currentHydrationPercent -= 1f;
            yield return new WaitForSeconds(10);
    
        }
    }
    // Update is called once per frame
    void Update()
    {
        distanceTraveled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if (distanceTraveled >= 5)
        {
            currentCalories -= 1;
            distanceTraveled = 0;
        }

        //testing the health bar
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentHealth -= 10;
        }
    }
}
