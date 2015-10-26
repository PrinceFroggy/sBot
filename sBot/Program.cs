using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace sBot
{
    static class Program
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6 && DwmIsCompositionEnabled())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
                Application.Run(new Form1());
            }
        }

/*
        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("sBot.HtmlAgilityPack.dll"))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return Assembly.Load(data);
            }
        }
*/

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("sBot.Properties.Resources.HtmlAgilityPack.dll"))
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    return Assembly.Load(data);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        static Assembly OnResolveAssembly(object sender, ResolveEventArgs e)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();

            var assemblyName = new AssemblyName(e.Name);
            var dllName = assemblyName.Name + ".dll";

            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(dllName));

            if (resources.Any())
            {
                var resourceName = resources.First();

                using (var stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        return null;
                    }

                    var block = new byte[stream.Length];

                    try
                    {
                        stream.Read(block, 0, block.Length);
                        return Assembly.Load(block);
                    }
                    catch (IOException)
                    {
                        return null;
                    }
                    catch (BadImageFormatException)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
