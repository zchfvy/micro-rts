#!/bin/bash
UNITY_PACKAGE_URL=http://netstorage.unity3d.com/unity/3829d7f588f3/MacEditorInstaller/Unity-5.5.2f1.pkg

echo 'Downloading from $UNITY_PACKAGE_URL'
wget --progress=dot:mega -O Unity.pkg $UNITY_PACKAGE_URL

echo 'Installing Unity'
sudo installer -dumplog -package Unity.pkg -target /
