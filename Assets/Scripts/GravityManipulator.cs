using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManipulator : MonoBehaviour
{
    private Vector3 gravityDirection;
    private Vector3 playerRotation;
    private GameObject instantiatedHologram;


    public Transform player;
    public GameObject hologram;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityDirection = player.parent.right * 9.81f;
            playerRotation = player.parent.eulerAngles + new Vector3(0,0,90f);
            HologramVisibility(true, new Vector3(2f, 1.5f, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityDirection = player.parent.right * (-9.81f);
            playerRotation = player.parent.eulerAngles + new Vector3(0, 0, -90f); // Vector3
            HologramVisibility(true, new Vector3(-2f, 1.5f, 0));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityDirection = player.parent.forward * 9.81f;
            playerRotation = player.parent.eulerAngles + new Vector3(-90, 0, 0);
            HologramVisibility(true, new Vector3(0, 1.5f, -2f));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gravityDirection = player.parent.forward * -9.81f;
            playerRotation = player.parent.eulerAngles + new Vector3(90, 0, 0);
            HologramVisibility(true, new Vector3(0, 1.5f, 2f));
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            ApplyCustomGravity();
        }
    }

    public void ApplyCustomGravity()
    {
        HologramVisibility(false, Vector3.zero);
        player.parent.rotation = Quaternion.Euler(playerRotation);
        Physics.gravity = gravityDirection;
    }
    
    public void HologramVisibility(bool state, Vector3 offset)
    {
        if (instantiatedHologram != null)
        {
            Destroy(instantiatedHologram);
            instantiatedHologram = null;
        }

        if (state)
        {
            instantiatedHologram = Instantiate(hologram, player);
            instantiatedHologram.transform.localPosition = player.localPosition + offset;
            instantiatedHologram.transform.rotation = Quaternion.Euler(playerRotation);

        }
    }
}
