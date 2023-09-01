using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviourPunCallbacks
{
    public GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(this.player.name, new Vector3(0, 0, 0), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
