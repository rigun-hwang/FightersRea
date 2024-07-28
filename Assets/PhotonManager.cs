using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 5 }, null);
        SceneManager.LoadScene("SampleScene");
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity);
    }
}
