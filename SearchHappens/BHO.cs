using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SHDocVw;
using mshtml;
using System.Runtime.InteropServices;

namespace SearchHappens
{
    [
        ComVisible(true),
        Guid("8a194578-81ea-4850-9911-13ba2d71efbd"),
        ClassInterface(ClassInterfaceType.None)
    ]

    public class BHO : IObjectWithSite
    { 
        IWebBrowser2 webBrowser;
        HTMLDocument document;


        // Implamentation of IWebBrowser2 events which are added in method SetSite(object site) lower. 
        #region WebBrowser events
        public void OnDocumentComplete(object pDisp, ref object URL)
        {
            //document = (HTMLDocument)webBrowser.Document;
            if (!ReferenceEquals(pDisp, webBrowser))
            {
                return;
            }
            // Here the page is fully loaded.
        }


        #endregion

        // Get access CMO
        // Field webBrowser initialization and destroying. Adding and removing events from webBrowser field.
        public int SetSite(object site)
        {
            if (site != null)
            {
                webBrowser = (WebBrowser)site;
                ((DWebBrowserEvents2_Event)webBrowser).DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
            }
            else
            {
                ((DWebBrowserEvents2_Event)webBrowser).DocumentComplete -= new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                webBrowser = null;
            }
            return 0;
        }

        public int GetSite(ref Guid guid, out IntPtr ppvSite)
        {
            IntPtr punk = Marshal.GetIUnknownForObject(webBrowser);
            int hr = Marshal.QueryInterface(punk, ref guid, out ppvSite);
            Marshal.Release(punk);
            return hr;
        }

        #region Create .dll file
        // Methods for create a ".dll" file of plugin
        public static string BHOKEYNAME = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";

        // Register BHO in system
        [ComRegisterFunction]
        public static void RegisterBHO(Type type)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(BHOKEYNAME, true);

            if (registryKey == null)
                registryKey = Registry.LocalMachine.CreateSubKey(BHOKEYNAME);

            string guid = type.GUID.ToString("B");
            RegistryKey ourKey = registryKey.OpenSubKey(guid);

            if (ourKey == null)
                ourKey = registryKey.CreateSubKey(guid);

            ourKey.SetValue("Alright", 1);
            registryKey.Close();
            ourKey.Close();
        }
        // Unregister BHO in system
        [ComUnregisterFunction]
        public static void UnregisterBHO(Type type)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(BHOKEYNAME, true);
            string guid = type.GUID.ToString("B");

            if (registryKey != null)
                registryKey.DeleteSubKey(guid, false);
        }
        #endregion
    }
}
