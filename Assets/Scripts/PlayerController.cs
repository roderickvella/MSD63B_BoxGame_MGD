using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerController : MonoBehaviour, IPunInstantiateMagicCallback
{

    private Vector3 playerScale;

    public FixedJoystick fixedJoystick;
    private PhotonView photonView;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        string colour = (string) instantiationData[0];
        float boxRandomSize = (float)instantiationData[1];
        print("Received Colour:" + colour);
        print("Received Size:" + boxRandomSize);


        //change colour
        if(colour == "Red")       
            GetComponent<SpriteRenderer>().color = Color.red;        
        else if(colour == "Blue")       
            GetComponent<SpriteRenderer>().color = Color.blue;        
        else if(colour == "Green")        
            GetComponent<SpriteRenderer>().color = Color.green;

        //change the box size
        playerScale = new Vector3(boxRandomSize, boxRandomSize, 1);

        //change the player's name
        GetComponentInChildren<TextMeshProUGUI>().text = info.photonView.Owner.NickName;
    }

    // Start is called before the first frame update
    void Start()
    {
        photonView = PhotonView.Get(this);

        if (photonView.IsMine)
        {
            //this player owns this photonview, therefore give him access to the joystick
            fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        }
        else
        {
            //if player object is not mine, then it should automatically be controlled by photon
            //data, therefore we are going to destroy the rigidbody
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //change the scale of the prefab square
        transform.localScale = new Vector3(playerScale.x, playerScale.y, playerScale.z);
    }
}
