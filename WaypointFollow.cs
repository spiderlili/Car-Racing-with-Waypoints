using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI to cycle through the waypoints in the scene - attach to character
//use Unity's waypoint system to give a visualisation of the waypoint path in the scene and add the ability to reorganise waypoints

public class WaypointFollow : MonoBehaviour{

//an array of game objects to hold all the waypoints
//  public GameObject[] waypoints;

//grab hold of the unity waypoint circuit - import from Unity Standard utility assets
  public UnityStandardAssets.Utility.WaypointCircuit circuit;
  
  //the waypoint the player is currently heading towards
  int currentWP = 0;
  
  float speed = 3.0f;
  float accuracy = 1.0f;
  float rotSpeed = 2.4f;
  
  void Start(){
  //populate the waypoint array automatically with all the objects with the waypoint tag
  //alternatively: drop game objects to the array in the inspector
  //  waypoints = GameObject.FindGameObjectsWithTag("waypoint");
  }

//change references to unity waypoints
  void LateUpdate(){
  //no point moving if there are no waypoints
    if(circuit.Waypoints.length == 0) return;
    
    //perform a 2D lookat - change to 3D for things that moves in 3D.e.g.airplanes or birds - waypoints[currentWP].transform.position.y
    Vector3 lookAtGoal = new Vector3(circuit.Waypoints.[currentWP].transform.position.x, this.transform.position.y, circuit.Waypoints.[currentWP].transform.position.z);
    Vector3 direction = lookAtGoal - this.transform.position;
    this.transform.rotation = Quarternion.Slerp(this.transform.rotation, Quarternion.LookRotation(direction), Time.deltaTime * rotSpeed);
    
    //if close enough to a waypoint: increase goal waypoint by 1
    if(direcion.magnitude < accuracy){
      currentWP++;
      
      //cycle around the waypoints
      if(currentWP >= circuit.Waypoints.Length){a
        currentWP = 0;
      }
    }
    //never stop at anything
    this.transform.Translate(0,0, speed*Time.deltaTime);
  }
}
