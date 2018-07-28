#!/usr/bin/env bash

source ./CONFIG.inc

deploy() {
	local DLL=$1

	if [ -f "./$PROJECTSDIR/bin/$DLL.dll" ] ; then
		cp "./$PROJECTSDIR/bin/$DLL.dll" "./GameData/$TARGETDIR/"

		if [ -d "${KSP_DEV}/GameData/$TARGETDIR/" ] ; then
			cp "./$PROJECTSDIR/bin/$DLL.dll" "${KSP_DEV}GameData/$TARGETDIR/"
		fi
	fi
}

VERSIONFILE=$PACKAGE.version

cp $VERSIONFILE "./GameData/$TARGETDIR"
deploy NavUtilLib
deploy NavUtilRPM