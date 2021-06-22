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
4. if you checked "includes preutterance", you must click "locate voice dir" to locate "UTAU\voice" folder
5. check "remove srt overlap" if you don't want subtitle's timeline has overlap
6. click export srt
7. recommend to close this program after checking srt file is you want

## Build
if you want to build by yourself, you need library [utauPlugin](https://github.com/delta-kimigatame/utauPlugin)
