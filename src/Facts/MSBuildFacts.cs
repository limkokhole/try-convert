﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Facts
{
    /// <summary>
    /// A bunch of values regarding MSBuild project files.
    /// </summary>
    public static class MSBuildFacts
    {
        /// <summary>
        /// Props files which are known to be imported in standard projects created from templates that can be converted to use the SDK
        /// </summary>
        public static ImmutableArray<string> PropsConvertibleToSDK => ImmutableArray.Create("Microsoft.Common.props");

        /// <summary>
        /// Targets files which are known to be imported in standard projects created from templates that can be converted to use the SDK.
        /// </summary>
        public static ImmutableArray<string> TargetsConvertibleToSDK => ImmutableArray.Create(
            "Microsoft.CSharp.targets",
            "Microsoft.VisualBasic.targets",
            "Microsoft.Portable.CSharp.targets",
            "Microsoft.Portable.VisualBasic.targets",
            "Microsoft.FSharp.Targets"
        );

        /// <summary>
        /// Mapping of PCL profiles to netstandard versions.
        /// </summary>
        public static ImmutableDictionary<string, string> PCLToNetStandardVersionMapping => ImmutableDictionary.CreateRange(new Dictionary<string, string>
        {
            { "Profile7",        "1.1"  },
            { "Profile31",       "1.0"  },
            { "Profile32",       "1.2"  },
            { "Profile44",       "1.2"  },
            { "Profile49",       "1.0"  },
            { "Profile78",       "1.0"  },
            { "Profile84",       "1.0"  },
            { "Profile111",      "1.0"  },
            { "Profile151",      "1.0"  },
            { "Profile157",      "1.0"  },
            { "Profile259",      "1.0"  },
        });

        public static ImmutableArray<string> GlobbedItemTypes => ImmutableArray.Create(
            "Compile",
            "EmbeddedResource",
            "None",
            "Page",
            "ApplicationDefinition"
            );

        public static ImmutableArray<string> UnnecessaryProperties => ImmutableArray.Create(
            // The following are unecessary in CPS and/or are already in the .NET SDK
            "ProjectGuid",
            "ProjectTypeGuids",
            "TargetFrameworkIdentifier",
            "TargetFrameworkVersion",
            "TargetFrameworkProfile",
            "FSharpTargetsPath",

            // This is not applicable in most cases, as older VS versions won't work with any modern .NET Core
            "MinimumVisualStudioVersion",

            // This is so unlikely to be changed from the default that we can just remove it
            "SchemaVersion",
            
            // This is set by F# legacy templates, but since we default to 64-bit on .NET Core this is unlikely to ever be meaningful
            "Prefer32Bit",

            // This is dropped in by templates and is so unlikely to ever be set that it's not worth keeping
            "VSToolsPath",

            // This is dropped in by templates, but is unlikely to be valid given that the .NET SDK specifies a minimum VS version that will work
            "VisualStudioVersion"
        );

        public static ImmutableArray<string> DefaultDefineConstants => ImmutableArray.Create(
            "DEBUG",
            "TRACE"
        );

        public static ImmutableArray<string> DefaultOutputPaths => ImmutableArray.Create(
            @"bin\Release\",
            @"bin\Debug\",
            @"bin\$(Configuration)\"
        );

        public static ImmutableArray<string> DefaultPlatformTargets => ImmutableArray.Create(
            "AnyCPU"
        );

        public static ImmutableArray<string> DefaultDebugTypes => ImmutableArray.Create(
            "full",
            "pdbonly"
        );

        public static ImmutableArray<string> UnnecessaryItemIncludes => ImmutableArray.Create(
            // FSharp.Core is referenced by default in the .NET SDK
            "FSharp.Core",

            // F# explicitly references this in old-style projects; it's not needed now
            "mscorlib",

            // Microsoft.CSharp is already shipped as a part of the .NET SDK
            "Microsoft.CSharp",

            // App.config is now deprecated, user needs to use to appsettings.json
            "App.config",

            // packages.config is now deprecated, user needs to move to PackageReference
            "packages.config",

            // System.Net.Http is a part of the .NET SDK now
            "System.Net.Http"
        );

        public static ImmutableDictionary<string, string> DefaultItemsThatHavePackageEquivalents => ImmutableDictionary.CreateRange(new Dictionary<string, string>
        {            
            { "System.Data.DataSetExtensions", "4.5.0" }
        });

        public static ImmutableArray<string> ItemsThatCanHaveMetadataRemoved => ImmutableArray.Create(
            "ProjectReference"
        );

        public static ImmutableArray<Guid> LegacyWebProjectTypeGuids => ImmutableArray.Create(
            Guid.Parse("{349c5851-65df-11da-9384-00065b846f21}"),
            Guid.Parse("{fae04ec0-301f-11d3-bf4b-00c04f79efbc}")
        );

        public const string DefaultSDKAttribute = "Microsoft.NET.Sdk";
        public const string LowestFrameworkVersionWithSystemValueTuple = "net47";
        public const string SharedProjectsImportLabel = "Shared";
        public const string NETCoreDesktopTFM = "netcoreapp3.0";
        public const string SystemValueTupleName = "System.ValueTuple";
        public const string DefineConstantsName = "DefineConstants";
        public const string OutputPathName = "OutputPath";
        public const string DebugTypeName = "DebugType";
        public const string SubTypeNodeName = "SubType";
        public const string DependentUponName = "DependentUpon";
        public const string PlatformTargetName = "PlatformTarget";
        public const string NetcoreappPrelude = "netcoreapp";
        public const string NetstandardPrelude = "netstandard";
        public const string MSBuildReferenceName = "Reference";
        public const string DesignerSubType = "Designer";
        public const string CodeSubTypeValue = "Code";
        public const string TargetFrameworkNodeName = "TargetFramework";
        public const string OutputTypeNodeName = "OutputType";
        public const string GenerateAssemblyInfoNodeName = "GenerateAssemblyInfo";
        public const string RequiredTargetFrameworkNodeName = "RequiredTargetFramework";
        public const string NameNodeName = "Name";
        public const string DocumentationFileNodeName = "DocumentationFile";
        public const string DefaultDocumentationFileLocation = @"bin\$(Configuration)\$(AssemblyName).XML";
        public const string CSharpFileSuffix = ".cs";
        public const string ProjectTypeGuidsNodeName = "ProjectTypeGuids";
        public const string HintPathNodeName = "HintPath";
    }
}
