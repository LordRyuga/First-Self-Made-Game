# First-Proper-Game
This was a game made by me for learning Unity. 

## Game Link:-  
[OneDrive Link](https://1drv.ms/f/c/ecc5fd92abdde1ac/EpjVUTbhgrpDqMSa9x4ibZgBfk-p_lRpidpM8kSTCaIDgg)

## IDEA OF GAME:-
* The player is a time traveler exploring zones representing different eras of humanity.  
* Each zone features unique quests and combat systems.  
* Time jumps trigger a transition zone with enemies attempting to stop the player.  
* The time jumps are triggered on the map in certain locations.  
* Player health is a timer indicating remaining survival time and is also the currency in game.  
* Hidden coins on the map slow the timer's depletion when collected.  
  
## TIMELINE:-  
  
### Week 1 (14-12-24 to 20-12-24):  
* Learnt first person movement and implemented it.  
* Learnt basics of CineMachine to make a jitter free first person camera and implemented it.  
* Implemented 'Dash' and 'Speed' potions (self made logic).  
* Created own sword swinging animations using free available 3d models in asset store.  
* Created logic for damaging gameobjects tagged as 'enemies' when swinging sword.  
* Started looking into terrain generation and tools for it.  
  
### Week 2 (21-12-24 to 27-12-24):  
* Learnt terrain making using terrain tools  
* Created and played around with terrain generation.  
* Generated terrain for first zone and its surrounding terrains.  
* Learnt how to make 'Save Game System' and implemented it.  
* Added trees and grass to terrain.  
* Fixed major movement bug in terrain (explained later)  
  
### Week 3 (28-12-24 to 3-1-25):  
* Lot of time wasted on searching for good 3d models for animals/wildlife that were free to vegitate the map. Didn't find many supporting the URP pipeline.  
* Added Village houses.  
* Spent time learning about animator and animator override controller.  
* Implemented some animations like door opening.  
* Added villagers and animations (imported from mixamo and free assets available online)  
* Added water in terrain and learnt (very basics) about post-processing to give effect as if we were underwater when we go below the water plane.  
* Added a pause screen to the game.  
  
### Week 4 (7-1-25 to 13-1-25):  
* Created a transistion terrrain and added enemies to it.  
* Created shooting logic (both for enemies and player)  
* Made shooting and idle and walking animations for player  
* Learnt about dialogue editor (free asset)  
* implemented dialogues and first basic quest in game.  
* Implemented special coins that slow down player's timer.  
* Prevented duping of said coins.  
  
### Week 5 (14-1-25 to 19-1-25):  
* Learnt about Audio sources and chanel mixers, added a volume controller and bgm and vfx.  
* Learnt about timelines in unity, added timeline animations for crossing transistions and Opening cutscene.   
* Added hidden coin.
* Added Magic and efffects for it.  



## --VERSION 1.2 CHANGELOG--
* Made the player unable to move during the opening cutscene
* Made the enemies more 'smart' by adding another state (read tutorial)
  
## MAJOR ISSUES WHILE MAKING AND HOW THEY WERE TACKLED:  
  
1) Movement issue after making terrain.  
    My movement script was preventing double jumps by using Physics spherecheck method to check for layermask labelled as ground. Due to this, when I was in contact with a high magnitude slope, and I pressed the jump key, It would still consider me to be on ground, essentially allowing me to wallclimb.  
   I first tried to use raycasting to check for the collission data to get the slope of the ground the player was on, but since the player's body is a capsule, raycasting vertically downwards from the center would not actually hit any surface as the point of contact was at an angle.  
   In order to fix this, I used SphereCasting which is a raycast but a thick ray is cast. This allowed me to get the approximate slope angle and I was able to prevent wallclimb by applying gravity whenever the slope angle exceeded the limit I set.  
  
2) Rendering pipelines: Being totally new to unity, I had no idea about these, and it took me quite some time to figure out that the assets that I was importing wouldn't render as they were made for a different pipeline than the one I am using. After understanding this, It also limited the assets I was finding by a large amount as finding free URP asstes that fit the theme of the game I was making was proving to be very hard.  
  
3) Figuring out PostProcessing: Unity has released it's latest version and there were almost no tutorials explaining post processing in the latest version using a CineMachine camera system. After referring to documentation and spending a lot of time on the game engine's settings, CineMachine's different options and Different camera settings, I was able to figure out how to set it up.  
  
4) When player is attacked by bear, bear performing multi hits.  
    The bear on attacking the player would damage the player multiple times as the collission(trigger) between the player and bear would occur multiple times within a very small time. This was fixed by adding a delay to the bear's attack, i.e. on being attacked by the bear, for a few frames, the player becomes invulnerable.  
  
5) High temps and requirements for game: This is still a decent issue, but currently, I have added a V-Sync option and Implemented occlusion culling to reduce requirements for game to run.

# Other readme files:

Bugs.md consists of active bugs that I have noticed in current release of game.  
Tutorial.md consists of the current features and quests in the game.
