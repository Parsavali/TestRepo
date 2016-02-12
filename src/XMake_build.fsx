// include Fake lib
#r "FakeLib.dll"
open Fake

// Properties
let buildDirCore = "C:\\Users\\D065230\\Documents\\Projects\\XmakeProjects\\xmakePhonewordProject_Fake\\src\\build\\core"
let androidDir = "C:\\Users\\D065230\\Documents\\Projects\\XmakeProjects\\xmakePhonewordProject_Fake\\src\\build\\android"

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDirCore
    CleanDir androidDir
)

let setParamsAndroid defaults =
        { defaults with
            Targets = ["clean;Build"]
            MaxCpuCount = Some (Some 1)
            NodeReuse = false
            Properties =
                [
                    "Configuration", "Debug";
                    "OutDir", buildDirCore
                ]
        }

let setParamsAndroidPackage defaults =
        { defaults with
            Targets = ["SignAndroidPackage"]
            MaxCpuCount = Some (Some 1)
            NodeReuse = false
            Properties =
                [
                    "Configuration", "Debug";
                    "OutDir", androidDir
                ]
        }

//Target "BuildApp" (fun _ ->
//    !! "/src/Phoneword/*.csproj"
//      |> MSBuildRelease buildDir "Build"
//      |> Log "AppBuild-Output: "
//)

Target "android-build" (fun () ->
    build setParamsAndroid  "src/Phoneword.sln" |> ignore
) 

Target "android-package" (fun () ->
    build setParamsAndroidPackage "src/Phoneword/Phoneword.csproj" |> ignore
)

// Dependencies
"Clean"
  ==> "android-build"
  ==> "android-package"

// start build
RunTarget()