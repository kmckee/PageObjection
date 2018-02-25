#!/bin/bash
VERSION=$1
ESCAPED_VERSION=`echo $VERSION | sed 's/\./\\\./g'`

# Make the version looks OK, and we're on a clean git status
if [ -z "$(git status --porcelain)" ]; then 
  echo "Git status looks clean, here we go..."
else 
	echo "Unable to release - you need to commit first!"
	exit 1
fi

# Update nuspec with version.
sed -i 's/<version>.*<\/version>/<version>'$ESCAPED_VERSION'<\/version>/g' PageObjection/PageObjection.nuspec

# Commit it, tag it, push it.
git commit -am "Release v"$VERSION
git tag -a v$VERSION -m "Release v"$VERSION
git push origin --tags

# Pack it
nuget pack PageObjection/

# Push it to nuget
nuget push PageObjection/PageObjection.$VERSION.nupkg -source https://api.nuget.org/v3/index.json

