# Batman Night Patrol
This 3D game contains animations for main character (Batman), for Idle, walking and running that is done via Belnd Tree.

Baked lighting may louds lights slower as batman walks through the city based on GPU.

Main camera follows the character and adjusts its rotation to the character's rotation when it is idle (it also follows the rotation on walking and running with damping)

Movement Keys are W, A, S, D and arrow keys in keyboard that are used for walking, if none of them is pushed the character stays idle.

By holding Shift while moving, Batman can run (unless the batman state is on stealth that has slower speed)

Bat Signal is shown as a rotating cube in the sky by pressing B on keyborad.

3 Batman States are Normal, Stealth and Alert, respectively can be achieved in the game by Pressing N (Normal), C (Stealth) and Space (Alert) on keyborad.

in Normal mode, Batman can stays idle or walk and run. 

In Stealth mode, Batman can not run even by holding shift but can walks and stays idle also after entering Stealth mode the interior lights and building rooms lights turn off.

In Alert mode Batman can stays idle, walk and run. Alarm sound is played in a loop and point light color changes from blue to red and converse after each 500 miliseconds.

Each Batman State has its own properties and they can not be executed at the same time as they are implemented by enums.

Playthrough of the game is available on Playthrough folder of repo.

The game is uplaoded it to google drive. Download it from the link in Build directory of repository.
