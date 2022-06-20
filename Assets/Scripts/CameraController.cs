using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform player;
    [Range(1.0f, 10.0f)][SerializeField] private float cameraOffSetX = 5.0f;
    [Range(1.0f, 10.0f)][SerializeField] private float cameraOffSetY = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < transform.position.x - (0.5f * cameraOffSetX))
        {
            transform.position = new Vector3(
                player.position.x + (0.5f * cameraOffSetX),
                transform.position.y,
                transform.position.z);
        }

        else if( player.position.x > transform.position.x + (0.5f * cameraOffSetX))
        {
            transform.position = new Vector3(
            player.position.x - (0.5f * cameraOffSetX),
            transform.position.y,
            transform.position.z);
        }


        if (player.position.y < transform.position.y - (0.5f * cameraOffSetY))
        {
            transform.position = new Vector3(
                transform.position.x,
                player.position.y + (0.5f * cameraOffSetY),
                transform.position.z);
        }

        else if (player.position.y > transform.position.y + (0.5f * cameraOffSetY))
        {
            transform.position = new Vector3(
                transform.position.x,
                player.position.y - (0.5f * cameraOffSetY),
                transform.position.z);
        }
    }
}
