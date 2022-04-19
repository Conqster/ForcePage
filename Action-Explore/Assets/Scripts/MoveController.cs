using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    float lerpPos;
    float moveSpeed = 1f;
    Vector3 currentLocation;
    Vector3 targetLocation = new Vector3(1, 1, 0);
    bool moving;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            MoveCharacter();
        }
    }

    public void MoveToTarget(Vector3 target)
    {
        currentLocation = transform.position;
        targetLocation = target;
        moving = true;
    }

    void MoveCharacter()
    {
        if (lerpPos < 1)
        {
            lerpPos += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(currentLocation, targetLocation, lerpPos);
        }
        else if (lerpPos >= 1)
        {
            moving = false;
            lerpPos = 0;
        }
    }


}
