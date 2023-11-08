using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient == false)
        {
            //do not show the change sizes button
            GameObject.Find("ButtonChangeSizes").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnButton()
    {
        TMP_Dropdown dropdown = GameObject.Find("DropdownColour").GetComponent<TMP_Dropdown>();
        //getting the selected colour by the player from the dropdown
        string colour = dropdown.options[dropdown.value].text;
        //generate a random number to determine the size of our box
        float boxRandomSize = Random.Range(0.5f, 0.8f);

        //we need to instanite the box prefab to all connected clients and share
        //the selected colour and random size to all connected clients, so
        //somehow we need to pass the colour and boxRandomSize data

        //Instantiate Box Prefab to all clients with custom data
        object[] myCustomInitData = new object[2] { colour, boxRandomSize };
        PhotonNetwork.Instantiate("Player",
            new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f),
            Quaternion.identity,
            0,
            myCustomInitData);
    }
}
