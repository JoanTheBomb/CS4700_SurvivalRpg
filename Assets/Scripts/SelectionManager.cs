using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;

public class SelectionManager : MonoBehaviour
{


    public static SelectionManager Instance { get; set; }


    public bool onTarget;
    public GameObject selectedObject;
    public GameObject interaction_Info_UI;
    TMP_Text interaction_text;


    public UnityEngine.UI.Image centerDotImage;
    public UnityEngine.UI.Image handIconImage;



 
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();
    }




    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }




    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

            if (interactable && interactable.playerInRange)
            {

                onTarget = true;
                selectedObject = interactable.gameObject;

                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);


                if (interactable.CompareTag("pickable"))
                {

                    centerDotImage.gameObject.SetActive(false);
                    handIconImage.gameObject.SetActive(true);


                }
                else
                {
                    centerDotImage.gameObject.SetActive(true);
                    handIconImage.gameObject.SetActive(false);
                }





            }
            else // if there is a hit, but no Interactable Script
            {
                onTarget = false;
                interaction_Info_UI.SetActive(false);
                centerDotImage.gameObject.SetActive(true);
                handIconImage.gameObject.SetActive(false);
            }

        }
        else // if there is no hit on any object
        {
            onTarget = false;
            interaction_Info_UI.SetActive(false);
            centerDotImage.gameObject.SetActive(true);
            handIconImage.gameObject.SetActive(false);
        }
    }
}