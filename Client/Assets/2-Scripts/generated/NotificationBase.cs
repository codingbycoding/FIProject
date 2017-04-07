// **********************************************************************
//
// Copyright (c) 2003-2016 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************
//
// Ice version 3.6.3
//
// <auto-generated>
//
// Generated from file `NotificationBase.ice'
//
// Warning: do not edit this file.
//
// </auto-generated>
//


using _System = global::System;
using _Microsoft = global::Microsoft;

#pragma warning disable 1591

namespace IceCompactId
{
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
                [_System.Runtime.InteropServices.ComVisible(false)]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1715")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1722")]
                [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724")]
                public partial interface NotificationBase : Ice.Object, NotificationBaseOperations_, NotificationBaseOperationsNC_
                {
                }
            }
        }
    }
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
            }
        }
    }
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public interface NotificationBasePrx : Ice.ObjectPrx
                {
                }
            }
        }
    }
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public interface NotificationBaseOperations_
                {
                }

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public interface NotificationBaseOperationsNC_
                {
                }
            }
        }
    }
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
                [_System.Runtime.InteropServices.ComVisible(false)]
                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public sealed class NotificationBasePrxHelper : Ice.ObjectPrxHelperBase, NotificationBasePrx
                {
                    #region Asynchronous operations

                    #endregion

                    #region Checked and unchecked cast operations

                    public static NotificationBasePrx checkedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        NotificationBasePrx r = b as NotificationBasePrx;
                        if((r == null) && b.ice_isA(ice_staticId()))
                        {
                            NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static NotificationBasePrx checkedCast(Ice.ObjectPrx b, _System.Collections.Generic.Dictionary<string, string> ctx)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        NotificationBasePrx r = b as NotificationBasePrx;
                        if((r == null) && b.ice_isA(ice_staticId(), ctx))
                        {
                            NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static NotificationBasePrx checkedCast(Ice.ObjectPrx b, string f)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        Ice.ObjectPrx bb = b.ice_facet(f);
                        try
                        {
                            if(bb.ice_isA(ice_staticId()))
                            {
                                NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static NotificationBasePrx checkedCast(Ice.ObjectPrx b, string f, _System.Collections.Generic.Dictionary<string, string> ctx)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        Ice.ObjectPrx bb = b.ice_facet(f);
                        try
                        {
                            if(bb.ice_isA(ice_staticId(), ctx))
                            {
                                NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static NotificationBasePrx uncheckedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        NotificationBasePrx r = b as NotificationBasePrx;
                        if(r == null)
                        {
                            NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static NotificationBasePrx uncheckedCast(Ice.ObjectPrx b, string f)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        Ice.ObjectPrx bb = b.ice_facet(f);
                        NotificationBasePrxHelper h = new NotificationBasePrxHelper();
                        h.copyFrom__(bb);
                        return h;
                    }

                    public static readonly string[] ids__ =
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::NotificationBase"
                    };

                    public static string ice_staticId()
                    {
                        return ids__[1];
                    }

                    #endregion

                    #region Marshaling support

                    public static void write__(IceInternal.BasicStream os__, NotificationBasePrx v__)
                    {
                        os__.writeProxy(v__);
                    }

                    public static NotificationBasePrx read__(IceInternal.BasicStream is__)
                    {
                        Ice.ObjectPrx proxy = is__.readProxy();
                        if(proxy != null)
                        {
                            NotificationBasePrxHelper result = new NotificationBasePrxHelper();
                            result.copyFrom__(proxy);
                            return result;
                        }
                        return null;
                    }

                    #endregion
                }

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public sealed class NotificationBaseSeqHelper
                {
                    public static void write(IceInternal.BasicStream os__, es.upm.fi.rmi.NotificationBase[] v__)
                    {
                        if(v__ == null)
                        {
                            os__.writeSize(0);
                        }
                        else
                        {
                            os__.writeSize(v__.Length);
                            for(int ix__ = 0; ix__ < v__.Length; ++ix__)
                            {
                                os__.writeObject(v__[ix__]);
                            }
                        }
                    }

                    public static es.upm.fi.rmi.NotificationBase[] read(IceInternal.BasicStream is__)
                    {
                        es.upm.fi.rmi.NotificationBase[] v__;
                        {
                            int szx__ = is__.readAndCheckSeqSize(1);
                            v__ = new es.upm.fi.rmi.NotificationBase[szx__];
                            for(int ix__ = 0; ix__ < szx__; ++ix__)
                            {
                                IceInternal.ArrayPatcher<es.upm.fi.rmi.NotificationBase> spx = new IceInternal.ArrayPatcher<es.upm.fi.rmi.NotificationBase>("::es::upm::fi::rmi::NotificationBase", v__, ix__);
                                is__.readObject(spx);
                            }
                        }
                        return v__;
                    }
                }

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public sealed class NotificationBasePrxSeqHelper
                {
                    public static void write(IceInternal.BasicStream os__, es.upm.fi.rmi.NotificationBasePrx[] v__)
                    {
                        if(v__ == null)
                        {
                            os__.writeSize(0);
                        }
                        else
                        {
                            os__.writeSize(v__.Length);
                            for(int ix__ = 0; ix__ < v__.Length; ++ix__)
                            {
                                es.upm.fi.rmi.NotificationBasePrxHelper.write__(os__, v__[ix__]);
                            }
                        }
                    }

                    public static es.upm.fi.rmi.NotificationBasePrx[] read(IceInternal.BasicStream is__)
                    {
                        es.upm.fi.rmi.NotificationBasePrx[] v__;
                        {
                            int szx__ = is__.readAndCheckSeqSize(2);
                            v__ = new es.upm.fi.rmi.NotificationBasePrx[szx__];
                            for(int ix__ = 0; ix__ < szx__; ++ix__)
                            {
                                v__[ix__] = es.upm.fi.rmi.NotificationBasePrxHelper.read__(is__);
                            }
                        }
                        return v__;
                    }
                }
            }
        }
    }
}

namespace es
{
    namespace upm
    {
        namespace fi
        {
            namespace rmi
            {
                [_System.Runtime.InteropServices.ComVisible(false)]
                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public abstract class NotificationBaseDisp_ : Ice.ObjectImpl, NotificationBase
                {
                    #region Slice type-related members

                    public static new readonly string[] ids__ = 
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::NotificationBase"
                    };

                    public override bool ice_isA(string s)
                    {
                        return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
                    }

                    public override bool ice_isA(string s, Ice.Current current__)
                    {
                        return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
                    }

                    public override string[] ice_ids()
                    {
                        return ids__;
                    }

                    public override string[] ice_ids(Ice.Current current__)
                    {
                        return ids__;
                    }

                    public override string ice_id()
                    {
                        return ids__[1];
                    }

                    public override string ice_id(Ice.Current current__)
                    {
                        return ids__[1];
                    }

                    public static new string ice_staticId()
                    {
                        return ids__[1];
                    }

                    #endregion

                    #region Marshaling support

                    protected override void writeImpl__(IceInternal.BasicStream os__)
                    {
                        os__.startWriteSlice(ice_staticId(), -1, true);
                        os__.endWriteSlice();
                    }

                    protected override void readImpl__(IceInternal.BasicStream is__)
                    {
                        is__.startReadSlice();
                        is__.endReadSlice();
                    }

                    #endregion
                }
            }
        }
    }
}