using System.Text;

static class Assets {
   static readonly String cdr = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

   // Part - Settings and Source
   internal static String Part(String part, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      var a_ = _Settings(content, part);
      var b_ = _Source(content, part);
      return String.Join("\n", $"//::Part:{part}\n", a_, b_);
   }

   // Source
   internal static String Source(String part, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      return $"//::Part:{part}\n" + _Source(content, part);
   }

   internal static String Source(String[] parts, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      String[] buf = new String[parts.Length];
      for (Int32 i = 0; i < parts.Length; i++) {
         buf[i] = $"//::Part:{parts[i]}\n" + _Source(content, parts[i]);
      }
      return String.Join("\n", buf);
   }

   // Settings
   internal static String Settings(String part, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      return $"//::Part:{part}\n" + _Settings(content, part);
   }

   internal static String Settings(String[] parts, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      String[] buf = new String[parts.Length];
      for (Int32 i = 0; i < parts.Length; i++) {
         buf[i] = $"//::Part:{parts[i]}\n" + _Settings(content, parts[i]);
      }
      return String.Join("\n", buf);
   }

   // Test
   internal static String Test(String part, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      return $"//::Part:{part}\n" + _Test(content, part);
   }

   internal static String Test(String[] parts, String path) {
      String content = File.ReadAllText(Path.Combine(cdr, path));
      String[] buf = new String[parts.Length];
      for (Int32 i = 0; i < parts.Length; i++) {
         buf[i] = $"//::Part:{parts[i]}\n" + _Test(content, parts[i]);
      }
      return String.Join("\n", buf);
   }

   /* **********   Locals   ********** */
   static String _Source(String content, String part) {
      Int32 pndx = content.IndexOf($"//::Part:{part}");
      Int32 ss = content.IndexOf("//:[Source", pndx);
      Int32 se = content.IndexOf("//:]Source", ss);
      return content[ss..(se + 10)];
   }

   static String _Settings(String content, String part) {
      Int32 pndx = content.IndexOf($"//::Part:{part}");
      Int32 ss = content.IndexOf("//:[Settings", pndx);
      Int32 se = content.IndexOf("//:]Settings", ss);
      return content[ss..(se + 12)];
   }

   static String _Test(String content, String part) {
      Int32 pndx = content.IndexOf($"//::Part:{part}");
      Int32 ss = content.IndexOf("//:[Test", pndx);
      Int32 se = content.IndexOf("//:]Test", ss);
      return content[ss..(se + 8)];
   }

}