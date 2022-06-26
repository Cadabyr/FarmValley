using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmValley.Player
{
    public class PlayerActionHandler : MonoBehaviour
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
                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 worldMousePosition2D = new Vector2(worldMousePosition.x, worldMousePosition.y);

                var distance = Vector2.Distance(worldMousePosition2D, transform.position);

                if(distance > 2)
                {
                    return;
                }

                Vector3 objectPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                objectPosition.z = 0;

                objectPosition.x = Mathf.Floor(objectPosition.x) + .5f;
                objectPosition.y = Mathf.Floor(objectPosition.y) + .5f;

                int layerMask = ~(LayerMask.GetMask("Player"));

                RaycastHit2D hit = Physics2D.Raycast(objectPosition, Vector2.zero, 1, layerMask);
                
                if(hit.collider != null)
                {
                    if(hit.collider.gameObject.CompareTag("Dirt"))
                    {
                        Destroy(hit.collider.gameObject);
                        return;
                    }
                }

                GameObject dirtObject = Instantiate(dirt);
                dirtObject.transform.position = objectPosition;

                Physics2D.IgnoreCollision(dirtObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }
    }
}