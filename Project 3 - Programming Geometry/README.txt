Project: Improvised Dice Game
Programmer: Khoi Ho
Description: This is a improvised dice game made with Unity. All the meshes of the dice are scripted instead of being made with 3D modelling software.
Technologies used: Unity 2019.4.21f1, GIMP 2.10.10

How to play:
	+ Press "Roll the Dice" to roll all 6 dice.
	+ Optionally, you have up to 3 times to roll one die. Click a die to roll it.
	+ Press "Pass" to end your turn.

Goal:
	Try to reach 500 points before the other player does.
		+ If player 2 reaches 500 points first, then player 2 wins.
		+ If player 1 reaches 500 points first, then player 2 must get the total score which is greater than that of player 1 in order to win, otherwise player 1 wins.

Scoring:
	In each turn, the score is the sum of all the values of the dice.
	Bonuses:
		1. If the two tetrahedral dice have the same value, 		their sum is multiplied by 2.
		2. If the two cubic dice have the same value,			their sum is multiplied by 4.
		3. IF the two octahedral dice have the same value, 		their sum is multiplied by 6.
		4. If any 2 of the conditions 1,2, and 3 are met,		50 points is added to the overall sum, or 100 points if all the conditions are met.
	Examples: 
		T4-T6-C5-C3-O1-O9 -> (4+6)   + (5+3)   + (1+9)         =  28 points
		T3-T3-C2-C4-O7-O8 -> (3+3)x2 + (2+4)   + (7+8)         =  33 points
                T4-T2-C6-C6-O4-O2 -> (4+2)   + (6+6)x4 + (4+2)         =  60 points
		T1-T2-C3-C2-O5-O5 -> (1+2)   + (3+2)   + (5+5)x6       =  68 points
                T4-T4-C1-C5-O3-O3 -> (4+4)x2 + (1+5)   + (3+3)x6 +  50 = 108 points
                T1-T1-C4-C4-O7-O7 -> (1+1)x2 + (4+4)x4 + (7+7)x6 + 100 = 220 points
