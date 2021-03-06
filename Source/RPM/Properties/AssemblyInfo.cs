﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("RPMHSI")]
[assembly: AssemblyDescription("Addon for Kerbal Space Program to interface with RasterPropMonitor")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(NavInstruments.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(NavInstruments.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(NavInstruments.LegalMamboJambo.Copyight)]
[assembly: AssemblyTrademark(NavInstruments.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("19cf6d35-3ea0-43d7-bb4c-af5ecaa86309")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyFileVersion("0.4.*")]
[assembly: AssemblyVersion(NavInstruments.Version.Number)]
[assembly: AssemblyFileVersion(NavInstruments.Version.Number)]
[assembly: KSPAssemblyDependency("KSPe", 2, 1)]
