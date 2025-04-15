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
      static String System => Assets.Source("System", "Sys\\SystemControl.js");
      static String Logger = Assets.Source("ScreenLogger", "Parts\\ScreenLogger.etjs");
      static String Tooling => Assets.Source("Tooling", "Sys\\Tooling.js");

      static String SyncronParts => Assembly.Synchrons;
      static String WispCore => Assembly.WispCore;
      static String LayoutParts => Assembly.LayoutParts;
      static String TaxelParts => Assembly.ContactParts;
      static String StylingClasses => Assembly.StylingParts;

      static String StylexCore => Assets.Source("Stylex", "Sys\\Stylex.js");
      static String WispTooling =>Assets.Source("CESTooling", "Sys\\CESTooling.js");

      // TypeStyle and Stylex Settings Overrides
      static String PartSettings = File.ReadAllText(Path.Combine(cd, "Config\\Settings.js"));
      static String StylexSettings = File.ReadAllText(Path.Combine(cd, "Config\\Stylex.js"));

      // Parts and Components
      static String EditTextBase => Assets.Part("EditTextBase", "Parts\\EditTextBase.etjs");
      static String ButtonUp => ItemMaster.ButtonUp;
      static String PersonContact => Assets.Part("PersonContact", "Components\\PersonContact.etjs");

      // Tests
      static String PersonContactTest => Assets.Test("PersonContact", "Components\\PersonContact.etjs");

      // Boot
      static String BootPatch = String.Join("\n", [
         "System.onBody(() => PersonContactTest.Run());"
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
        <script id="post">
        {{Bom.Tooling}}
        {{Bom.SyncronParts}}
        {{Bom.System}}
        </script>
        <script id="kernel">
        {{Bom.StylingClasses}}
        {{Bom.WispTooling}}
        {{Bom.WispCore}}
        {{Bom.StylexCore}}
        </script>
        <script id="config">
        {{Bom.Logger}}
        {{Bom.PartSettings}}
        {{Bom.StylexSettings}}
        {{Bom.EditTextBase}}
        </script>
        <script id="parts">
        {{Bom.ButtonUp}}
        {{Bom.LayoutParts}}
        {{Bom.TaxelParts}}
        </script>
        <script id="components">
        {{Bom.PersonContact}}
        </script>
        <script id="boot">
        {{Bom.PersonContactTest}}
        {{Bom.BootPatch}}
        </script>
        </head>
        </html>
        """;
}

interface HttpHeaders {
   static readonly Byte[] OK = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n".U8B();
}