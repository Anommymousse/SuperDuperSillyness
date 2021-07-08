Ok, most of this code is pants!
And it is a throwaway noddy (Something simple to do)

The following are the problems I knew about and didn't care about. Rationale : Simplier to finish, you wouldn't do this in a real game.

1) References and class static functions generating links to things that shouldn't be linked. This is known as side-effects. 
Reason: Level of effort for one throwaway prototype project. 

2) Memory is not clean and stuff isn't allocated on a pool leading to memory leaks.
Cleaning memory etc... I would opt now for addressables and a pool manager.

3) Naming is dodgy as hell and inconsistent, I would normally go through and use rider to correct the inconsistent naming but for this project it's not required or long term.
The names themselves are sometimes deceptive like menustartspaused which while techinically correct doesn't set time update to 0f.

There's probably more but that's all I remember.

Things you might be able to look at.
1) Ragdoll
2) Quit
3) Loadscene
4) Score and highscore to playerprefs - but this is a poor implementation of it with sideeffects used to update it in another function.


Things used.
1) Unity terrain with image*
2) Master audio
3) Text animator*
4) UDRP*
5) sinisterfonts
6) music and sound effects and art from asset store, except the ball that I did in houdini.

*I'd not used these, or been a while like UDRP.