# Xamarin.Android Binding for a Kotlin Android Archive

This reposiory contains a kotlin bubles picker library built and bound using a xamarin.android project and then referenced and used by a xamarin application

## Kotlin and Bubles Picker

We use the bubbles picker as an example of a kotlin library, copied source and updated dependencies in order to build latest version of the android archive (.aar). The archived has been place into the `Kotlin/VendorsFramework/` folder

## Xamarin Binding

The bubbles picker android archive copied to the Jar folder of the project and a few transformations applied to exclude not used dependecies from being generated as C# classes. Two issues with the `getBackground` and `setBackground` has been fixed to reflect real kotlin intent. Two important packages have been added to support kotlin libraries:

- [Android Kotlin BindingSupport Nuget](https://www.nuget.org/packages/Xamarin.Kotlin.BindingSupport/)
- [Android Kotling StdLib Nuget](https://www.nuget.org/packages/Xamarin.Kotlin.StdLib/)

## Xamarin App

A simple xamarin app has been created in order to instanciate and render the bubbles picker control. The project references the bubbles picker xamarin.android binding and instantiate the control in the same way as the native sample application does.

## Demo

<img src="SolutionItems/bubbles-picker.gif" alt="bubbles picker demo" height="350" style="display:inline-block;" />
