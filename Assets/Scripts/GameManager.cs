using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameObject PlayerPrefab;
    public GameObject FireBlast, RogueKnife, PaladinSword, WarriorSword, FloorTile, FloorTileList;
    public Sprite FloorTile1;
    public Sprite FloorTile2;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name,
                new Vector2(Random.Range(-7, 8), 0), Quaternion.identity);
        LoadFloor();
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} disconnect", otherPlayer.NickName);
    }
    private void LoadFloor()//Random for every player
    {
        for (float x = -10.5f; x < 11.5f; x++)
        {
            for (float y = -5.5f; y < 6.5f; y++)
            {
                if (Random.Range(0, 2) == 0) FloorTile.GetComponent<SpriteRenderer>().sprite = FloorTile1;
                else FloorTile.GetComponent<SpriteRenderer>().sprite = FloorTile2;
                GameObject FloorTileObj = Instantiate(FloorTile, new Vector2(x, y), Quaternion.identity);
                FloorTileObj.transform.SetParent(FloorTileList.transform, false);
            }
        }
    }
    
}
