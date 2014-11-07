using UnityEngine;
using System.Collections;

//Eugene ch'ng
//www.youtube.com/watch?v=9ix5oRau-2k
public class teleportLocation : MonoBehaviour {


	public GameObject[] teleportLoc;
	public string tagName;
	private int locIndex =  0 ;

	// time
	private float  	lastInterval;
	private float 	elapsedTime;
	private bool  	timeStarted;
	private float 	waitTime = 1; 
	private bool   keyPressed = false;

	// Use this for initialization
	void Start () 
	{
		tagName = "Teleport";

		// find all the game objects with this this tag
		teleportLoc = GameObject.FindGameObjectsWithTag(tagName);


		// just a text locations of Teleport
		for(int i = 0; i < teleportLoc.Length;i++)
		{
			print( "Location:" + teleportLoc[i].transform.position);
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// this mechism below is to prevent the camera from jumping to quickly
		if( keyPressed)
		{

			if (IntervalComplete(waitTime))
			{

				keyPressed =  false ;

			}

			return;
		
		}

		// if space is Pressed

		if(Input.GetKey(KeyCode.Space))	
		{
			locIndex++; // increment the location  index

			// make  sure the index doesn't go over length  of array
			if(locIndex >= teleportLoc.Length) locIndex = 0;

				//Change object location 
				transform.position = teleportLoc[locIndex].transform.position;

				keyPressed = true ;

		}


	
	}

	//============================== Time Interval 
		
	private bool IntervalComplete (float waitTime)
	{
		elapsedTime = Time .realtimeSinceStartup - lastInterval; 

		//if idle time is great than wait time
		//if idle for too loon
		if(elapsedTime > waitTime)
		{
			lastInterval = Time.realtimeSinceStartup;

			return true;
		
		}

	
	return false;

	}
}

