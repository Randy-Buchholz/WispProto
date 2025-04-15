using IM = ItemMaster;

internal interface Assembly {
   static String ContactParts => String.Join("\n", IM.PersonName, IM.StreetAddress, IM.Municipality);
   static String LayoutParts => String.Join("\n", IM.FormLine);
   static String StylingParts => String.Join("\n", IM.Chroma, IM.Styling);
   static String Synchrons => Assets.Source(["Gate", "Barrier"], "Sys\\Synchrons.ctjs");
   static String WispCore => Assets.Source(["SimpleSettings", "SimpleSheets", "SimpleElms", "Stereotyping"], "Sys\\CES.js");

}

static class ItemMaster {
   static readonly String cd = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
   static String PartFile(String file) => Path.Combine(cd, "Parts", file);

   internal static String FormLine => Assets.Part("FormLine", PartFile("FormLine.etjs"));
   internal static String ButtonUp => Assets.Part("ButtonUp", PartFile("ButtonUp.etjs"));

   internal static String Chroma => Assets.Part("Chroma", PartFile("Chroma.ctjs"));
   internal static String Styling => Assets.Part("Styling", PartFile("Styling.ctjs"));

   internal static String PersonName => Assets.Part("PersonName", PartFile("PersonName.etjs"));
   internal static String StreetAddress => Assets.Part("StreetAddress", PartFile("StreetAddress.etjs"));
   internal static String Municipality => Assets.Part("Municipality", PartFile("Municipality.etjs"));
}