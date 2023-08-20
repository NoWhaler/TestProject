# Test Project

## Realisation
There are a total of 3 scenes on the project. On the first scene there is a button "Play", by clicking on it, we go to the "loading stage". We have a script "LoadingScene", which handles moving to next scene with preloading of objects. This script essentially loads the next scene in the background while showing a loading progress using the _progressBar, and it also preloads certain prefabs specified in the preloadContainer array. It's designed to  minimize loading times and providing visual feedback during the loading process. After moving to the play scene, we see the player and a joystick on the screen to control movement. As the player moves closer to the wall, we can notice that the camera does not go beyond the walls, but moves closer to the player.
