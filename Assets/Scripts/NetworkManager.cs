using Newtonsoft.Json;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        photonView = PhotonView.Get(this);
    }

    public void ChangeSizes(string jsonSizes)
    {
        //send message to all connected players (even the master client) with random sizes
        photonView.RPC("ChangeSizesRPC", RpcTarget.All, jsonSizes);
    }

    [PunRPC]
    public void ChangeSizesRPC(string jsonSizes)
    {
        print("ChangeSizesRPC:" + jsonSizes);
        List<PlayerInfo> playersInfos = JsonConvert.DeserializeObject<List<PlayerInfo>>(jsonSizes);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            player.GetComponent<PlayerController>().ChangeSizeFromMaster(playersInfos);
        }
    }



}
