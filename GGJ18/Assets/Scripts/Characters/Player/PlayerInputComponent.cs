﻿using Assets.Scripts.Echoes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    [RequireComponent(typeof(Player))]
    public class PlayerInputComponent : MonoBehaviour
    {
        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                GetComponent<Player>().Scream();
            }
            else if(Input.GetButtonDown("Fire2") && GetComponent<Player>().holdingObject)
            {
                Debug.Log("Throw object");
            }
            else if(Input.GetButtonDown("Use"))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out hit))
                {
                    var distance = (transform.position - hit.transform.position).magnitude;
                    if (hit.transform.gameObject.GetComponent<InterractableObject>() != null && distance <= 2.0f)
                    {
                        var player = GetComponent<Player>();
                        var go = hit.transform.gameObject;
                        if (GetComponent<Player>().holdingObject)
                        {
                            player.SwapObjects(go);
                        }
                        else
                        {
                            player.PickupObject(go);
                        }
                    }
                }
            }
        }
    }
}
