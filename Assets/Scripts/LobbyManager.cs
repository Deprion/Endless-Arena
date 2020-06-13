using Photon.Pun;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject ConnectingStatus;
    private bool AvailableToConnect;
    public Sprite pers1;
    public Sprite pers2;
    public Sprite pers3;
    private void Start()
    {
        if (PhotonNetwork.NickName.Length <= 1)
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        }
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "015";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        ConnectingStatus.SetActive(false);
        AvailableToConnect = true;
    }
    public void CreateRoom()
    {
        if (AvailableToConnect)
            PhotonNetwork.CreateRoom(null);
    }
    public void JoinRoom()
    {
        if (AvailableToConnect)
            PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
