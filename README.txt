Lost in Ice demo

How to Play:

Run the Lost in Ice application within this file after extracting.


Controls:

The main menu is navigated with a mouse, click to select a button. 

The player is controlled by wasd and/or the arrow keys. Click the text panel to continue text or hide the text if it is finished.



Features:

Features a simple main menu and background with a quit button that can exit the game and a start button to go to the test scene. Both buttons give optical feedback on use and on hover.

This game includes locations with ice. The ice can be used to slide across the map and the player won't slip if on solid ground. Sliding into an item will cause a collision and stop player movement. Non sliding tiles are indicated with a 2d collider trigger and show up as green grassy patches.

When the player gets to the end of a map, the screen has a gentle fade to black and fades in to the next map.

A particle emitter under the character that shows up as bits of snow or ice when sliding and unable to change directions.

The player has a blended animator with individual images between all directions and a simple idle animation.

Map was created with individual sprites using multiple layers of the tilemap object in Unity. Multiple layers allows some layers to collide and allows layered sprite images. Some of these layers are non collidable such as the ground.

Cinemachine was created to keep the character within the screen and bound to the area.

Main menu and levels feature two different free bgm soundtracks provided by Music Zapsplat.

UI is mostly screen size scalable. It should look okay in most pc aspect ratios. Text includes a simple demo click to continue which will be expanded on to allow more story and interaction text later.

Uses Textmesh Pro and Cinemachine along with some asset bundles.



Bugs:

Character can be stopped by collisions from the side if trying to slide across the ice.

Diagonal movement was not originally planned, but seems to be an interesting mechanic that doesn't get seen very often for ice sliding puzzles. It provides unique twists and options to the player and has been kept.

Can move before hiding text.

Can't complete level as there is no way to interact with the dirt to cover up the hole to continue.
