# Source:
https://github.com/softwarecrafters/kata-log/blob/master/_katas/mars-rover-kata.md

# Your Task
You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. 

Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

# Requirements
- You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
- The rover always starts at position (0,0) and facing N direction
- Once a command is processed then the Rover ouputs its current position (x,y) and the currently faced direction (N,S,E,W) with the following format: N:1,4
- The rover receives a character array of commands.
- Implement commands that move the rover forward/backward (f,b).
- Implement commands that turn the rover left/right (l,r).
- Implement wrapping at edges. But be careful, planets are spheres. 
    Assuming a grid of 5 by 5 then:
    Connect the x edge to the other x edge, so (1,1) for x-1 to (5,1), 
    but connect vertical edges towards themselves in inverted coordinates, so (1,1) for y-1 connects to (1,5).
- Implement obstacle detection before each move to a new square. 
    If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point, 
    aborts the sequence and reports the obstacle with format:
    0:N:3,4
    noting 0:, direction N and position 3,4

# Rules
- Hardcore TDD. No Excuses!
- Change roles (driver, navigator) after each TDD cycle.
- No red phases while refactoring.
- Be careful about edge cases and exceptions. We can not afford to lose a mars rover, just because the developers overlooked a null pointer.

## NOTE: look out for branches in this repo to checkout solutions for this