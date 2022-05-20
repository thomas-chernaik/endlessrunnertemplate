using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectController : MonoBehaviour
{
    //the mover object which gets spawned
    public GameObject moverObject;
    //the size of the mover object
    public float moverSize;
    //the value to set the speed to at the next cycle.
    public float nextSpeed;
    //the origin from which location is calculated
    public Vector3 origin;
    //the moverNum to despawn at
    public float despawnNum;
    //a list of all the movers
    public List<GameObject> movers;
    //the degree through the cycle the mover is in
    public float degree;
    //the time elapsed
    private float timeElapsedThisCycle = 0;
    //the length of a cycle, calculated from speed
    private float cycleLength;
    //the speed that all moving objects move at (units per second)
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        //set speed to nextSpeed
        speed = nextSpeed;
        //calculate the cycleLength from speed (time = distance / speed)
        cycleLength = moverSize / speed;
        //instantiate the initial movers.
        for(int i=0; i<despawnNum; i++)
        {
            //instantiate the next object.
            movers.Add(Instantiate(moverObject));
            //move the next object to the origin
            movers[movers.Count - 1].transform.position = origin;
            //set the controller to self
            movers[movers.Count - 1].GetComponent<MovingObject>().controller = this;
            //set the moverNum
            movers[movers.Count - 1].GetComponent<MovingObject>().moverNum = i;
        }
    }
    //a method to allow movers to remove themself from the list movers when they despawn.
    public void Die(GameObject mover)
    {
        movers.Remove(mover);
    }
    // Update is called once per frame
    void Update()
    {
        //increment timeElapsedThisCycle
        timeElapsedThisCycle += Time.deltaTime;
        //check if timeElapsed > cycleLength
        if(timeElapsedThisCycle > cycleLength)
        {
            //increment the num in all movers
            foreach(GameObject mover in movers)
            {
                mover.GetComponent<MovingObject>().moverNum++;
            }
            //set timeElapsedThisCycle to zero
            timeElapsedThisCycle = 0;
            //set degree to zero
            degree = 0;
            //update speed to the next speed
            speed = nextSpeed;
            //calculate the cycleLength from speed (time = distance / speed)
            cycleLength = moverSize / speed;
            //instantiate the next object.
            movers.Add(Instantiate(moverObject));
            //move the next object to the origin
            movers[movers.Count - 1].transform.position = origin;
            //set the controller to self
            movers[movers.Count - 1].GetComponent<MovingObject>().controller = this;
        }
        else
        {
            degree = timeElapsedThisCycle / cycleLength;
        }    
    }
}
