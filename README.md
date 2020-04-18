# Psyche-Cobalt-Mobile-App
Scaffolding Code for Psyche Cobalt Class Mobile App cpastones

## Tech stack
React Native

Unity

## After forking/cloning the project (Required)
To install node modules do:
````
npm install 
````
Ensure that all peer dependencies are installed by checking:
````
npm ls --depth=0
````

## Also ensure that the Unity project is properly configured:

### Make sure react-native-unity-view is linked

To link the node modules do:
````
react-native link react-native-unity-view
````

### Configure Player Settings

1. First Open Unity Project.
2. Click Menu: File => Build Settings => Player Settings
3. Change `Product Name` to Name of the Xcode project, You can find it follow `ios/${XcodeProjectName}.xcodeproj`.

##### Additional changes for Android Platform

Under `Other Settings` make sure `Scripting Backend` is set to `IL2CPP`, and `ARM64` is checked under `Target Architectures`.

Under `Other Settings` make sure `Auto Graphics API` is unchecked, and the list only contains `OpenGLES3` and `OpenGLES2` in that order.

Also, ensure that lowest Supported Android version is set to `Android Oreo (APK 26)` and the Highest Supported Android version is either set to `Most Recent' or 'Android Pie (APK 28)`

### Export Unity

To export the Unity game go to Build -> Export Android

This will export Unity to android/UnityExport.

### Configure Native Build

#### Android Build

Make alterations to the following files:

- `android/settings.gradle`

```
...
include ":UnityExport"
project(":UnityExport").projectDir = file("./UnityExport")
```

##### After Unity Export

Node: After each Unity Export to Android you will have to delete the following from the bottom of the android/UnityExport/build.gralde

    bundle {
        language {
            enableSplit = false
        }
        density {
            enableSplit = false
        }
        abi {
            enableSplit = true
        }
    }

## Build android
Run following command from your project root directory:
````
react-native run-android
````

If the metro bundler closes open a separate terminal and run:
````
react-native start
````
Then on your original terminal try again or run:
````
react-native run-android --no-packager
````


## Build ios
Run following command from your project root directory:
````
react-native run-ios
````

