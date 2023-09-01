using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    public GameObject createBtn = null;
    public GameObject joinBtn = null;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CountOfRooms == 0)
        {
            createBtn.SetActive(true);
            joinBtn.SetActive(false);
        }
        else
        {
            createBtn.SetActive(false);
            joinBtn.SetActive(true);
        }
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("mainRoom");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("mainRoom");
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
