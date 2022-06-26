using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Player
{
    public class PlayerDigAction : MonoBehaviour
    {
        public GameObject dirt;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePos);
                objectPosition.z = 0;

                RaycastHit2D hit = Physics2D.Raycast(objectPosition, -Vector2.up);
                
                if(hit.collider != null)
                {
                    Destroy(hit.collider.gameObject);
                    return;
                }

                GameObject dirtObject = Instantiate(dirt);
                dirtObject.transform.position = objectPosition;
            }
        }
    }
}