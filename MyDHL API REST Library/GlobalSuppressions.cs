// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Provides more flexibility to users. Also would be a breaking change.", Scope = "namespaceanddescendants", Target = "~N:MyDHLAPI_REST_Library")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Would be a breaking change.", Scope = "namespaceanddescendants", Target = "~N:MyDHLAPI_REST_Library")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "Deserialization would fail when this was blank. Also a breaking change.", Scope = "member", Target = "~P:MyDHLAPI_REST_Library.Objects.ShipmentResponse.ODDUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "For this library, only English error will be used to aid in support globally.", Scope = "namespaceanddescendants", Target = "~N:MyDHLAPI_REST_Library")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "Would be a breaking change.", Scope = "namespaceanddescendants", Target = "~N:MyDHLAPI_REST_Library")]
