# MT6-Nubmaster
Utility for generating .nub files for MT6

Full disclosure, I'm a novice, so expect the source to be ass.

## Preparing your audio track
The program is making a few assumptions in it's current version:
 - You're using 44100hz Stereo
 - Your song has an intro to play it in, and the rest is to be looped, or the whole song is to be looped.
 - This means that your file should end where the loop ends.
 - Additonally, if you export the intro by itself as it's own seperate .snd file, you can save yourself writing down and typing in the samples later (I reccomend this. If you put your intro in it's own stereo track, you can solo it to export as a seperate file very quickly).

## Instructions
 - Start by selecting an existing .nub file you want to use as a template. **This will NOT replace the file you select, don't worry.** It's just getting the extra header data so you're replacing, so ideally it should work in story.
 - Next, select your custom .snd file containing your new song.
 - Now, set the starting point of your loop. You can either manually type in the loop start point in Samples, Import a seperate .snd file that contains just the intro, loop the whole file front to back, or set no loop.
 - Generate your file!

The program will create the new .nub file in the same location as the .exe itself, and it will cancel if a .nub file with the same name is present. No accidentally overwriting files.
