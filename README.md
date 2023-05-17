# carrom-assignment-
carrom assignment by aryan sharma
Game physics : for game physics i added a circle collider to the pucks so that they react properly when colliding with the striker.
i also added empty game objects to the borders of the carrom board and assigned them boxcollider component to make the boundaries.

game mechnics: i implemented a slider which helps place the striker as the player desires by setting the min and max values of the slider
to the transform of the striker
i used a line renderer for an indicator of the direction of the shot. this line rendered takes in the negative mouse coordinates as we are shooting in 
the opposite direction 
for adding power  i used the add force function on the striker and if the striker velocity becomes near zero the striker is reset at the starting position

Scoring : for scoring i added circle colliders to the the pockets of the board. then i added tags to the pucks. then i implemeted the 
ontriigerenter2d method . i set the pockets to ontrigger and added a condtion if gameobjects with tag collide points will increase by one and 
2 in case of queen. the points are displayed in a text format 

Timer : i took a variable and stored the time as 120f secondds and the time got reduced by dectuting time.deltatime in the update function 
then i displayed it on the canvas. if the timer value is zero then a game over canvass would be enabled containg the gamer over banner 

Game management and Ai: i set a global count variable and incremented it each time striker got reset.if the count was divisible by 2 a gameobject
would get active which reffered to the playing parties (named x and y)

for ai , i implemted the another script on the other striker which first find the transform positions of the targets(i.e pucks)
then added the same mechanics using the corutine function and target the pucks 
however this didnt seem to work properly and its not in the final video 

