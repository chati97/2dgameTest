using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    GameObject vehicle = null;
    GameObject weapon1 = null;
    GameObject weapon2 = null;
    bool[] controll = new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        vehicle = GameObject.Find("vehicle");
        weapon1 = GameObject.Find("weapon1");
        weapon2 = GameObject.Find("weapon2");
        this.transform.SetParent(vehicle.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += controll[0] || controll[1] || controll[2] ? Vector3.zero : Vector3.up * Time.deltaTime;
                vehicle.transform.position += controll[0] ? Vector3.up * Time.deltaTime : Vector3.zero;
            }
            if (Input.GetKey(KeyCode.A))
            {
                weapon1.transform.Rotate(controll[1] ? new Vector3(0, 0, 20) * Time.deltaTime : Vector3.zero);
                weapon2.transform.Rotate(controll[2] ? new Vector3(0, 0, -20) * Time.deltaTime : Vector3.zero);
                this.transform.position += controll[0] || controll[1] || controll[2] ? Vector3.zero : Vector3.left * Time.deltaTime;
                vehicle.transform.position += controll[0] ? Vector3.left * Time.deltaTime : Vector3.zero;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += controll[0] || controll[1] || controll[2] ? Vector3.zero : Vector3.down * Time.deltaTime;
                vehicle.transform.position += controll[0] ? Vector3.down * Time.deltaTime : Vector3.zero;
            }
            if (Input.GetKey(KeyCode.D))
            {
                weapon1.transform.Rotate(controll[1] ? new Vector3(0, 0, -20) * Time.deltaTime : Vector3.zero);
                weapon2.transform.Rotate(controll[2] ? new Vector3(0, 0, 20) * Time.deltaTime : Vector3.zero);
                this.transform.position += controll[0] || controll[1] || controll[2] ? Vector3.zero : Vector3.right * Time.deltaTime;
                vehicle.transform.position += controll[0] ? Vector3.right * Time.deltaTime : Vector3.zero;
            }
            if (Input.GetKey(KeyCode.E))
            {
                controll = new bool[5];
            }
            if (controll[3])
            {

            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Q)) {
            switch (collision.name)
            {
                case "Controller":
                    controll[0] = true;
                    break;
                
                case "Weapon1":
                    controll[1] = true;
                    break;
                case "Weapon2":
                    controll[2] = true;
                    break;
                case "Shield":
                    controll[3] = true;
                    break;
                default:
                    break;
            }
        }
    }
}
