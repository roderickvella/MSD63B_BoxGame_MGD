using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerController : MonoBehaviour, IPunInstantiateMagicCallback
{
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        string colour = (string) instantiationData[0];
        float boxRandomSize = (float)instantiationData[1];
        print("Received Colour:" + colour);
        print("Received Size:" + boxRandomSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
