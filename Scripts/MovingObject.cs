using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public int moverNum;
    public MovingObjectController controller;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Late Update is called once per frame after Update
    void LateUpdate()
    {
        //the position will be the (moverNum + degree) * moverSize * direction + origin
        gameObject.transform.position = (moverNum + controller.degree) * controller.moverSize * direction + controller.origin;
        //check object is not past despawn distance
        if(moverNum >= controller.despawnNum)
        {
            controller.Die(gameObject);
            Destroy(gameObject);
        }
    }
}
