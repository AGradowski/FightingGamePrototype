# Camera Scripts

The folder for containg the documentation for anything relaed to the scripts connected to the Camera

## CameraFollow

Script for following the players.

### Variables

* private GameObject player1 - the Player one object, for determinig middle point
* private GameObject player2 - the Player two object, for determinig middle point
* public float a,b - variables for the better control of the camera movement (as per f=aX +b)
* public Vector3 startPosition - the start position vector of the camera, added to the middle between players

### Functions

* Start() - sets the camera at the starting position
* Uptade() - uptades the camera using LookAt functions to set Forward vector, then it takes the forward vector, a and b parameters, and the distance between players to move camera accoridningly
