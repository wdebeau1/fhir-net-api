﻿using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Hl7.Fhir")]
[assembly: AssemblyDescription("FHIR Resource model classes for .NET")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("HL7 International")]
[assembly: AssemblyProduct("FHIR")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: ComVisible(false)]

#if DEBUG
[assembly: InternalsVisibleTo("HL7.Fhir.Tests")]
#endif

[assembly: CLSCompliant(true)]

[assembly: AssemblyVersion("0.0.81.2634")]
[assembly: AssemblyFileVersion("0.0.81.2634")]

#if RELEASE
[assembly:AssemblyKeyFileAttribute("..\\FhirNetApi.snk")]
#endif
