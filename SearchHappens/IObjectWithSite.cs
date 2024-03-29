﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SearchHappens
{
    [
        ComVisible(true),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
        Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352")
    ]

    // Interface for BHO
    public interface IObjectWithSite
    {
        [PreserveSig]
        int SetSite([MarshalAs(UnmanagedType.IUnknown)]object site);
        [PreserveSig]
        int GetSite(ref Guid guid, out IntPtr ppvSite);
    } 
}
