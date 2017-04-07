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
// Generated from file `AvatarService.ice'
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
                public partial interface AvatarService : Ice.Object, AvatarServiceOperations_, AvatarServiceOperationsNC_
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
                public delegate void Callback_AvatarService_getAvatar(es.upm.fi.rmi.AvatarProfile ret__);

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public delegate void Callback_AvatarService_updateAvatar();
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
                public interface AvatarServicePrx : Ice.ObjectPrx
                {
                    es.upm.fi.rmi.AvatarProfile getAvatar(string name);

                    es.upm.fi.rmi.AvatarProfile getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_getAvatar> begin_getAvatar(string name);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_getAvatar> begin_getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult begin_getAvatar(string name, Ice.AsyncCallback cb__, object cookie__);

                    Ice.AsyncResult begin_getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

                    es.upm.fi.rmi.AvatarProfile end_getAvatar(Ice.AsyncResult r__);

                    void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile);

                    void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, Ice.AsyncCallback cb__, object cookie__);

                    Ice.AsyncResult begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

                    void end_updateAvatar(Ice.AsyncResult r__);
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
                public interface AvatarServiceOperations_
                {
                    es.upm.fi.rmi.AvatarProfile getAvatar(string name, Ice.Current current__);

                    void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, Ice.Current current__);
                }

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public interface AvatarServiceOperationsNC_
                {
                    es.upm.fi.rmi.AvatarProfile getAvatar(string name);

                    void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile);
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
                public sealed class AvatarServicePrxHelper : Ice.ObjectPrxHelperBase, AvatarServicePrx
                {
                    #region Synchronous operations

                    public es.upm.fi.rmi.AvatarProfile getAvatar(string name)
                    {
                        return this.getAvatar(name, null, false);
                    }

                    public es.upm.fi.rmi.AvatarProfile getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return this.getAvatar(name, ctx__, true);
                    }

                    private es.upm.fi.rmi.AvatarProfile getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
                    {
                        checkTwowayOnly__(__getAvatar_name);
                        return end_getAvatar(begin_getAvatar(name, context__, explicitCtx__, true, null, null));
                    }

                    public void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile)
                    {
                        this.updateAvatar(avatarProfile, null, false);
                    }

                    public void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        this.updateAvatar(avatarProfile, ctx__, true);
                    }

                    private void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
                    {
                        end_updateAvatar(begin_updateAvatar(avatarProfile, context__, explicitCtx__, true, null, null));
                    }

                    #endregion

                    #region Asynchronous operations

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_getAvatar> begin_getAvatar(string name)
                    {
                        return begin_getAvatar(name, null, false, false, null, null);
                    }

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_getAvatar> begin_getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return begin_getAvatar(name, ctx__, true, false, null, null);
                    }

                    public Ice.AsyncResult begin_getAvatar(string name, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_getAvatar(name, null, false, false, cb__, cookie__);
                    }

                    public Ice.AsyncResult begin_getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_getAvatar(name, ctx__, true, false, cb__, cookie__);
                    }

                    private const string __getAvatar_name = "getAvatar";

                    public es.upm.fi.rmi.AvatarProfile end_getAvatar(Ice.AsyncResult r__)
                    {
                        IceInternal.OutgoingAsync outAsync__ = IceInternal.OutgoingAsync.check(r__, this, __getAvatar_name);
                        try
                        {
                            if(!outAsync__.wait())
                            {
                                try
                                {
                                    outAsync__.throwUserException();
                                }
                                catch(Ice.UserException ex__)
                                {
                                    throw new Ice.UnknownUserException(ex__.ice_name(), ex__);
                                }
                            }
                            es.upm.fi.rmi.AvatarProfile ret__;
                            IceInternal.BasicStream is__ = outAsync__.startReadParams();
                            ret__ = null;
                            ret__ = es.upm.fi.rmi.AvatarProfile.read__(is__, ret__);
                            outAsync__.endReadParams();
                            return ret__;
                        }
                        finally
                        {
                            outAsync__.cacheMessageBuffers();
                        }
                    }

                    private Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_getAvatar> begin_getAvatar(string name, _System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        checkAsyncTwowayOnly__(__getAvatar_name);
                        IceInternal.TwowayOutgoingAsync<es.upm.fi.rmi.Callback_AvatarService_getAvatar> result__ =  getTwowayOutgoingAsync<es.upm.fi.rmi.Callback_AvatarService_getAvatar>(__getAvatar_name, getAvatar_completed__, cookie__);
                        if(cb__ != null)
                        {
                            result__.whenCompletedWithAsyncCallback(cb__);
                        }
                        try
                        {
                            result__.prepare(__getAvatar_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                            IceInternal.BasicStream os__ = result__.startWriteParams(Ice.FormatType.DefaultFormat);
                            os__.writeString(name);
                            result__.endWriteParams();
                            result__.invoke();
                        }
                        catch(Ice.Exception ex__)
                        {
                            result__.abort(ex__);
                        }
                        return result__;
                    }

                    private void getAvatar_completed__(Ice.AsyncResult r__, es.upm.fi.rmi.Callback_AvatarService_getAvatar cb__, Ice.ExceptionCallback excb__)
                    {
                        es.upm.fi.rmi.AvatarProfile ret__;
                        try
                        {
                            ret__ = end_getAvatar(r__);
                        }
                        catch(Ice.Exception ex__)
                        {
                            if(excb__ != null)
                            {
                                excb__(ex__);
                            }
                            return;
                        }
                        if(cb__ != null)
                        {
                            cb__(ret__);
                        }
                    }

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile)
                    {
                        return begin_updateAvatar(avatarProfile, null, false, false, null, null);
                    }

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return begin_updateAvatar(avatarProfile, ctx__, true, false, null, null);
                    }

                    public Ice.AsyncResult begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_updateAvatar(avatarProfile, null, false, false, cb__, cookie__);
                    }

                    public Ice.AsyncResult begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_updateAvatar(avatarProfile, ctx__, true, false, cb__, cookie__);
                    }

                    private const string __updateAvatar_name = "updateAvatar";

                    public void end_updateAvatar(Ice.AsyncResult r__)
                    {
                        end__(r__, __updateAvatar_name);
                    }

                    private Ice.AsyncResult<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> begin_updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, _System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        IceInternal.OnewayOutgoingAsync<es.upm.fi.rmi.Callback_AvatarService_updateAvatar> result__ = getOnewayOutgoingAsync<es.upm.fi.rmi.Callback_AvatarService_updateAvatar>(__updateAvatar_name, updateAvatar_completed__, cookie__);
                        if(cb__ != null)
                        {
                            result__.whenCompletedWithAsyncCallback(cb__);
                        }
                        try
                        {
                            result__.prepare(__updateAvatar_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                            IceInternal.BasicStream os__ = result__.startWriteParams(Ice.FormatType.DefaultFormat);
                            es.upm.fi.rmi.AvatarProfile.write__(os__, avatarProfile);
                            result__.endWriteParams();
                            result__.invoke();
                        }
                        catch(Ice.Exception ex__)
                        {
                            result__.abort(ex__);
                        }
                        return result__;
                    }

                    private void updateAvatar_completed__(es.upm.fi.rmi.Callback_AvatarService_updateAvatar cb__)
                    {
                        if(cb__ != null)
                        {
                            cb__();
                        }
                    }

                    #endregion

                    #region Checked and unchecked cast operations

                    public static AvatarServicePrx checkedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        AvatarServicePrx r = b as AvatarServicePrx;
                        if((r == null) && b.ice_isA(ice_staticId()))
                        {
                            AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static AvatarServicePrx checkedCast(Ice.ObjectPrx b, _System.Collections.Generic.Dictionary<string, string> ctx)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        AvatarServicePrx r = b as AvatarServicePrx;
                        if((r == null) && b.ice_isA(ice_staticId(), ctx))
                        {
                            AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static AvatarServicePrx checkedCast(Ice.ObjectPrx b, string f)
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
                                AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static AvatarServicePrx checkedCast(Ice.ObjectPrx b, string f, _System.Collections.Generic.Dictionary<string, string> ctx)
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
                                AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static AvatarServicePrx uncheckedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        AvatarServicePrx r = b as AvatarServicePrx;
                        if(r == null)
                        {
                            AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static AvatarServicePrx uncheckedCast(Ice.ObjectPrx b, string f)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        Ice.ObjectPrx bb = b.ice_facet(f);
                        AvatarServicePrxHelper h = new AvatarServicePrxHelper();
                        h.copyFrom__(bb);
                        return h;
                    }

                    public static readonly string[] ids__ =
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::AvatarService"
                    };

                    public static string ice_staticId()
                    {
                        return ids__[1];
                    }

                    #endregion

                    #region Marshaling support

                    public static void write__(IceInternal.BasicStream os__, AvatarServicePrx v__)
                    {
                        os__.writeProxy(v__);
                    }

                    public static AvatarServicePrx read__(IceInternal.BasicStream is__)
                    {
                        Ice.ObjectPrx proxy = is__.readProxy();
                        if(proxy != null)
                        {
                            AvatarServicePrxHelper result = new AvatarServicePrxHelper();
                            result.copyFrom__(proxy);
                            return result;
                        }
                        return null;
                    }

                    #endregion
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
                public abstract class AvatarServiceDisp_ : Ice.ObjectImpl, AvatarService
                {
                    #region Slice operations

                    public es.upm.fi.rmi.AvatarProfile getAvatar(string name)
                    {
                        return getAvatar(name, Ice.ObjectImpl.defaultCurrent);
                    }

                    public abstract es.upm.fi.rmi.AvatarProfile getAvatar(string name, Ice.Current current__);

                    public void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile)
                    {
                        updateAvatar(avatarProfile, Ice.ObjectImpl.defaultCurrent);
                    }

                    public abstract void updateAvatar(es.upm.fi.rmi.AvatarProfile avatarProfile, Ice.Current current__);

                    #endregion

                    #region Slice type-related members

                    public static new readonly string[] ids__ = 
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::AvatarService"
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

                    #region Operation dispatch

                    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
                    public static Ice.DispatchStatus getAvatar___(AvatarService obj__, IceInternal.Incoming inS__, Ice.Current current__)
                    {
                        Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
                        IceInternal.BasicStream is__ = inS__.startReadParams();
                        string name;
                        name = is__.readString();
                        inS__.endReadParams();
                        es.upm.fi.rmi.AvatarProfile ret__ = obj__.getAvatar(name, current__);
                        IceInternal.BasicStream os__ = inS__.startWriteParams__(Ice.FormatType.DefaultFormat);
                        es.upm.fi.rmi.AvatarProfile.write__(os__, ret__);
                        inS__.endWriteParams__(true);
                        return Ice.DispatchStatus.DispatchOK;
                    }

                    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
                    public static Ice.DispatchStatus updateAvatar___(AvatarService obj__, IceInternal.Incoming inS__, Ice.Current current__)
                    {
                        Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
                        IceInternal.BasicStream is__ = inS__.startReadParams();
                        es.upm.fi.rmi.AvatarProfile avatarProfile;
                        avatarProfile = null;
                        avatarProfile = es.upm.fi.rmi.AvatarProfile.read__(is__, avatarProfile);
                        inS__.endReadParams();
                        obj__.updateAvatar(avatarProfile, current__);
                        inS__.writeEmptyParams__();
                        return Ice.DispatchStatus.DispatchOK;
                    }

                    private static string[] all__ =
                    {
                        "getAvatar",
                        "ice_id",
                        "ice_ids",
                        "ice_isA",
                        "ice_ping",
                        "updateAvatar"
                    };

                    public override Ice.DispatchStatus dispatch__(IceInternal.Incoming inS__, Ice.Current current__)
                    {
                        int pos = _System.Array.BinarySearch(all__, current__.operation, IceUtilInternal.StringUtil.OrdinalStringComparer);
                        if(pos < 0)
                        {
                            throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
                        }

                        switch(pos)
                        {
                            case 0:
                            {
                                return getAvatar___(this, inS__, current__);
                            }
                            case 1:
                            {
                                return Ice.ObjectImpl.ice_id___(this, inS__, current__);
                            }
                            case 2:
                            {
                                return Ice.ObjectImpl.ice_ids___(this, inS__, current__);
                            }
                            case 3:
                            {
                                return Ice.ObjectImpl.ice_isA___(this, inS__, current__);
                            }
                            case 4:
                            {
                                return Ice.ObjectImpl.ice_ping___(this, inS__, current__);
                            }
                            case 5:
                            {
                                return updateAvatar___(this, inS__, current__);
                            }
                        }

                        _System.Diagnostics.Debug.Assert(false);
                        throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
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