# ust2srt
convert ust file to srt subtitle

## Download
[Release](https://github.com/namaeclog/ust2srt/releases)

## Feature
* convert ust to srt file in exactly time point
* adjust position of break line
* srt time line includes preutterance
* limit max R in each R section
* custom symbol of lyric's left and right

## Requirement
.NET 5.0 runtime

## Usage
1. select a ust file
2. using Enter and Backspace to adjust break line in textarea
3. check "includes preutterance" if you want starting point of subtitle at note's preutterance
6. check "remove overlap of srt" if you don't want subtitle's timeline has overlap
7. check "show all prefix and suffix" if you want exporting includes prefix and suffix whitch is not assign in ust
8. click export srt
9. recommend to close this program after checking srt file is you want

## UTAU\voice location
this program will automatically locate UTAU\voice folder from registry  
if your computer had not installed UTAU or this program can't locates the UTAU\voice folder please click "Locate UTAU\voice manually" to locate voice folder  
hover on "Locate UTAU\voice manually" button can show which folder this program located

## Build
if you want to build by yourself, you need library [utauPlugin](https://github.com/delta-kimigatame/utauPlugin)
