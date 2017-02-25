#!/bin/sh

project=MicroRts

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -runEditorTests \
  -editorTestResultFile "$(pwd)/Test/$project.xml" \
  -quit
