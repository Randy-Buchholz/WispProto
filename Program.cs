#pragma warning disable CS0164 // This label has not been referenced
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using static System.Text.Encoding;

static class Host {
   // Env    
   internal static readonly String cd = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
   internal static Byte[] U8B(this String self) => UTF8.GetBytes(self);
   internal static String U8S(this Byte[] self) => UTF8.GetString(self);
   internal static String U8S(this ArraySegment<Byte> self) => UTF8.GetString(self);

   // Hosting "127.0.0.1 5150 E:\\Min\\Min.exe"
   static readonly IPAddress IP = IPAddress.Parse("127.0.0.1");
   static readonly Int32 Port = 5150;
   static readonly String Browser = "E:\\Min\\Min.exe";
   static readonly String Url = $"http://127.0.0.1:5150/";

   // Node
   static readonly TcpListener Listener;
   static void Main() { Console.ReadKey(); }
   static Host() {
      RunListener:
      Listener = new(IP, Port);
      Listener.Start();

      RunTestClient:
      Process.Start(Browser, Url);

      ProcessHttpGet:
      GetRequest(out _, out NetworkStream stream);
      stream.Write(HttpHeaders.OK);
      stream.Write(HttpResponse);
      stream.Close();

      static void GetRequest(out String request, out NetworkStream stream) {
         TcpClient client = Listener.AcceptTcpClient();
         stream = client.GetStream();
         Byte[] buffer = new Byte[1024];
         Int32 bytesRead = stream.Read(buffer, 0, buffer.Length);
         request = buffer[..bytesRead].U8S();
      }
   }

   interface Bom {
      static String Tooling => Assets.Source("Tooling", "Tooling.js");
      static String Classes => Assets.Source(["Chroma", "Styling"], "Classes.ctjs");
      static String Stylex => Assets.Source("Stylex", "Stylex.js");
      static String WispCore => Assets.Source(["SimpleSettings", "SimpleSheets", "SimpleElms", "Stereotyping"], "CES.js");
      static String BodyReadyCheck => Assets.Source("ReadyCheck", "SystemControl.js");

      // Consolidated Settings
      static String Settings = File.ReadAllText(Path.Combine(cd, "Settings.js"));

      static String AbstractElements => Assets.Part("EditTextBase", "AbstractElements.etjs");
      static String CommonElements => Assets.Part("ButtonUp", "CommonElements.etjs");
      static String PartTaxels => Assets.Source(["FormLine", "PersonName", "StreetAddress", "Municipality"], "PartTaxels.etjs");
      static String PersonContactTaxel => Assets.Source("PersonContact", "PersonContactTaxel.etjs");


      // Tests
      static String PersonContactTest => Assets.Test("PersonContact", "PersonContactTaxel.etjs");
      static String ButtonsTest => Assets.Test("ButtonUp", "CommonElements.etjs");

      // Boot
      static String BootPatch = String.Join("\n", [
         "ReadyCheck.onBody(() => PersonContactTest.Deploy());",
         "ReadyCheck.onBody(() => ButtonTests.Run());"
         ]);
   }

   internal static Byte[] HttpResponse => Document.U8B();
   static String Document = $$"""
        <!DOCTYPE html>
        <html lang="en">
        <head>
        <meta charset="UTF-8">  
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Wisp</title>
        <script id="kernel">
        {{Bom.Tooling}}
        {{Bom.Classes}}
        {{Bom.Stylex}}
        {{Bom.BodyReadyCheck}}
        </script>
        <script id="common">
        {{Bom.WispCore}}
        {{Bom.Settings}}
        {{Bom.AbstractElements}}
        {{Bom.CommonElements}}
        </script>
        <script id="parts">
        {{Bom.PartTaxels}}
        </script>
        <script id="components">
        {{Bom.PersonContactTaxel}}
        </script>
        <script id="boot">
        {{Bom.PersonContactTest}}
        {{Bom.ButtonsTest}}
        {{Bom.BootPatch}}
        </script>
        </head>
        </html>
        """;
}

interface HttpHeaders {
   static readonly Byte[] OK = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n".U8B();
}