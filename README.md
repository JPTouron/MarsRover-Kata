# Source:
https://github.com/softwarecrafters/kata-log/blob/master/_katas/mars-rover-kata.md

# Your Task
You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. 

Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

# Requirements
- [x] You are given the initial starting point (0,0:N) of a rover.
- [x] 0,0 are X,Y co-ordinates on a grid of (10, 10)
- [x] N is the direction it is facing (i.e N,S,E,W)
- [x] L and R allow the rover to rotate left and right.
- [x] F allows the rover to move one point in the current direction.
- [x] The rover receives a char array of commands e.g. RFFLF and returns the finishing point after the moves e.g. 2,1:N
- [x] The rover wraps around if it reaches the end of the grid. (meaning: coordinate 0,10 when y+1, becomes 0,0, and the same for x ord)
- [] The grid may have obstacles. If a given sequence of commands encounters on obstacle, the rover moves up to the last possible point and reports the obstacle e.g. O:2,2:N, where 2,2 is the current position of the rover

## Extra requirements

- [] Make rove move backwards, the command for it should be B
- [] Each processed command outputs the current position, and direction. Running a command like FR, would output: 
    0,1:N
    0,1:E
- Grid should be of variable size


# Rules
- Hardcore TDD. No Excuses!
- Change roles (driver, navigator) after each TDD cycle.
- No red phases while refactoring.
- Be careful about edge cases and exceptions. We can not afford to lose a mars rover, just because the developers overlooked a null pointer.
- {% include starting_points.md %}

## NOTE: look out for branches in this repo to checkout solutions for this