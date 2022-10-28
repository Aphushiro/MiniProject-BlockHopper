# MiniProject-BlockHopper
## Overview of idea
The idea of the project is heavily inspired by the game “Refunct” which is a game I personally found on Steam some years ago. In Block hopper the player is able to move a character in a first-person perspective using keyboard controls, as well as camera controls through mouse movements. Upon launching the game, the player is presented to a tutorial world which is only completable using every keyboard interaction available. These are jump, double jump and wall jump. The player can also enter the Challenge world through a doorway. In this challenge world the player is presented with a new world with a much longer and challenging track. At the start of the level, the user is presented the option to turn checkpoints on and off.

### Main parts of the game are:
* Player - first person perspective view with the following controls:
  * Movement along x and z axis using WASD or arrow keys
  * Jump, doublejump and walljump using space bar
  * Horizontal mouse movements rotate the player, while vertical movements result in up/down rotation of the camera
* Portals - Moving the player through them results in a switch of scenes.
* Levels - Two scenes. One is the tutorial world, while the other is the challenge world which the player can chose to play with or without checkpoints
* Checkpoints - Activation of checkpoints instantiates invisible “safety nets” that returns the player to the checkpoints upon falling off the track. The checkpoints themselves are also invisible. The checkpoints can be toggled on and off using the checkpoint control station at the start of the challenge world

### Project parts
* Scripts
  * CheckpointActivator - Activates “safety nets” upon being triggered by the player’s collider. 
  * CheckpointToggler - Sets the checkpoints’ activation state to true or false upon being triggered by the player’s collider
  * CheckpointTP - The safety nets of the game. Teleports the player back to a position upon being triggered by the player’s collider
  * InteractSwitch - Contains the active state for the checkpoint activators, and updates them whenever the state is toggled.
  * MouseLook - Allows the player to rotate the camera up and down, as well as allowing for rotation of the player
  * PingPong - Used for making certain obstacles move
  * PlayerMovement - Allows for player movement, jumping, double jumping and wall jumping as well as simulating gravity on the player. The script  also resets the player position in case the player falls off the map as well as allowing for the player to close the application.
  * PortalTrigger - Switches between scenes upon being triggered by the player’s collider
* Models and prefabs
  * Prefab of the portal object
* Materials
  * Basic Unity materials, some of which are reused between objects. Used for: the player, the planes of each world, the checkpoint indicator sphere
  * Basic transparent Unity materials used for the interactive checkpoint toggle triggers
* Scenes
  * Tutorial world - presents all intended movement options in the game, 1 by 1
  * Challenge world - world meant to challenge the player
  * (Debug world - used for initially meant for both debugging, and for allowing the player to roam freely. Access was eventually disabled from the game build)
* Testing
  * Game was tested only on windows
  
## Time management
| Task | Time spent |
| --- | --- |
| Conceptualizing idea and checking with project component requirements | 30 minutes |
| Basic player movement (Walk, single jump, gravity, camera controls) via. video tutorial | 30 minutes |
| Wall jump implementation | 45 minutes |
| Double jump implementation | 10 minutes |
| Minor scripts: PingPong Obstacle, PortalTrigger | 30 minutes |
| Tutorial level with probuilder | 2 hours 30 minutes |
| Writing checkpoint scripts: CheckpointTp, CheckpointToggler, CheckpointActivator | 30 minutes |
| Movement polishing | 1 hour |
| Challenge level | 4 hours 30 minutes|
| Writing ReadMe | 2 hours |
| In total | 14 hours 30 minutes|

## References
* [FIRST PERSON MOVEMENT in Unity - FPS Controller](https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys)
* [Teleporting Character - issue with transform.position in Unity 2018.3](https://answers.unity.com/questions/1614287/teleporting-character-issue-with-transformposition.html)
