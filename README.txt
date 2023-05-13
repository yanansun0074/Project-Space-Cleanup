README

	1 	Name: Yanan Sun
	2	UNI; ys3610
	3	Date of submission: 02/20/2023
	4	Computer Platform: 
		macOS: 13.2 (22D49)
		Graphics: Intel Iris Plus Graphics 1536 MB
	5	Unity Version: 2021.3.17f1
	6	Mobile Platform:
		iOS: 16.1.1
		Device name: iPhone 13 Pro
	7	Description
	•	Player controls the pan and yaw of a spaceship moving at a constant speed.

	•	UI design: main UI consists of 
	◦	a joystick controller controlling pan and yaw of the spaceship
	◦	Timer. Countdown from 60 seconds.
	◦	Health bar: 5 hearts at the beginning. Collisions with moons/planet/satellites will decrease health bar by 1. When num of hearts decreases to 0, the game is over.
	◦	Value: reflect the value of collected trash.
	◦	“Speed up” button: Speed up the ship. Speed returns to initial speed shortly.
	◦	“Back camera”/”Front camera” button: switch view between front and back camera.
	◦	“Restart” button: restart the game session
	◦	“Help button”: Guidance about how to play the game will appear. The game is paused. Click on the button again to resume. 

	•	Implement game scene: a self-rotating planet. Six moons orbiting around the planet on the belt. Each moon has two pieces of small moon trash (red cube) orbiting around it. Eight space trash (brown cylinder) orbit around the planet. Two satellites orbit around the planet high above.

	•	Collecting trash: Detect collision between spaceship and trash (moon trash/space trash). When this collision happens, the collided trash turns green, flies toward the ship, and disappears. “Value” on the UI will increase accordingly.
	// Used OnTriggerEnter()
	•	When switching to the back camera view, user could collect the trash by touching the screen. Similar effects will be triggered and reflected.
		// Used ScreenPointToRay()

	•	Detect collision between spaceship and other objects (planet/moon/satellite). When this collision happens, the light of the spaceship turns red for a few seconds. If a moon is hit, an additional piece of moon trash is generated around that moon. “Value” and “Health” bar on the UI will decrease accordingly.
	// Used OnCollisionEnter()

	•	Track the position of the spaceship. If it is far (InBound collider) from the planet, a warning will appear on the UI and “value” will decrease accordingly. If getting too far (OutBound collider), the ship will turn 180 degrees and move toward the planet. 
	◦	“Value” stops decreasing when the spaceship gets back to the InBound. 
	// Used OnTriggerEnter(), OnTriggerStay(), and OnTriggerExit()

	•	When there is no trash in the space, a winning panel will appear exhibiting the score, time, and health bar.
	// Used FindGameObjectsWithTag() in “TrashCounter” script 
	
	•	Game starts with a starting menu with game name, instruction, “Start” button, and “Quit” button. User clicks on the “Start” button to start the game. 
	// Used SceneManager()
	
	8	Application of Nielson’s Usability Heuristics
The joystick and buttons match the system and the real world. Users could easily understand the meaning of these components and use them. The “restart” button supports user control and freedom, allowing players to restart the game session as they wish. Buttons meet consistency and standard, meeting user’s expectations. The UI also applies minimalist design, including only necessary components. The warning message triggered when the spaceship is too far away helps users recognize their errors. The “help” button offers help and documentation to users.

	9	Problems solved
	•	Outbound detection caused endless loop 
	•	Difference between OnTriggerEnter and OnCollisionEnter. Solve the problem of passing through objects
	•	Pause time in game
	•	Rotate around an orbiting object.
	•	UI layers order. Occlusion by transparent layers
	•	Skybox lightning
	•	Set light color in script 
	

	10	Free assets
	•	Starfield skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717
	•	Simple heart health (picture only)
	•	Joystick pack: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
	•	Blockly Space Fighter: https://assetstore.unity.com/packages/3d/vehicles/space/blocky-space-fighter-88440
	•	Images from Google Image as planet texture and start menu background.

