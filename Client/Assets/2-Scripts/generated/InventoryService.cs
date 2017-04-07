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
// Generated from file `InventoryService.ice'
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
                public partial interface InventoryService : Ice.Object, InventoryServiceOperations_, InventoryServiceOperationsNC_
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
                public delegate void Callback_InventoryService_getInventory(es.upm.fi.rmi.RmiInventory ret__);

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public delegate void Callback_InventoryService_updateItem();
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
                public interface InventoryServicePrx : Ice.ObjectPrx
                {
                    es.upm.fi.rmi.RmiInventory getInventory();

                    es.upm.fi.rmi.RmiInventory getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_getInventory> begin_getInventory();

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_getInventory> begin_getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult begin_getInventory(Ice.AsyncCallback cb__, object cookie__);

                    Ice.AsyncResult begin_getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

                    es.upm.fi.rmi.RmiInventory end_getInventory(Ice.AsyncResult r__);

                    void updateItem(es.upm.fi.rmi.RmiItem rmiItem);

                    void updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_updateItem> begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem);

                    Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_updateItem> begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__);

                    Ice.AsyncResult begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, Ice.AsyncCallback cb__, object cookie__);

                    Ice.AsyncResult begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

                    void end_updateItem(Ice.AsyncResult r__);
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
                public interface InventoryServiceOperations_
                {
                    es.upm.fi.rmi.RmiInventory getInventory(Ice.Current current__);

                    void updateItem(es.upm.fi.rmi.RmiItem rmiItem, Ice.Current current__);
                }

                [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.3")]
                public interface InventoryServiceOperationsNC_
                {
                    es.upm.fi.rmi.RmiInventory getInventory();

                    void updateItem(es.upm.fi.rmi.RmiItem rmiItem);
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
                public sealed class InventoryServicePrxHelper : Ice.ObjectPrxHelperBase, InventoryServicePrx
                {
                    #region Synchronous operations

                    public es.upm.fi.rmi.RmiInventory getInventory()
                    {
                        return this.getInventory(null, false);
                    }

                    public es.upm.fi.rmi.RmiInventory getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return this.getInventory(ctx__, true);
                    }

                    private es.upm.fi.rmi.RmiInventory getInventory(_System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
                    {
                        checkTwowayOnly__(__getInventory_name);
                        return end_getInventory(begin_getInventory(context__, explicitCtx__, true, null, null));
                    }

                    public void updateItem(es.upm.fi.rmi.RmiItem rmiItem)
                    {
                        this.updateItem(rmiItem, null, false);
                    }

                    public void updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        this.updateItem(rmiItem, ctx__, true);
                    }

                    private void updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
                    {
                        end_updateItem(begin_updateItem(rmiItem, context__, explicitCtx__, true, null, null));
                    }

                    #endregion

                    #region Asynchronous operations

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_getInventory> begin_getInventory()
                    {
                        return begin_getInventory(null, false, false, null, null);
                    }

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_getInventory> begin_getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return begin_getInventory(ctx__, true, false, null, null);
                    }

                    public Ice.AsyncResult begin_getInventory(Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_getInventory(null, false, false, cb__, cookie__);
                    }

                    public Ice.AsyncResult begin_getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_getInventory(ctx__, true, false, cb__, cookie__);
                    }

                    private const string __getInventory_name = "getInventory";

                    public es.upm.fi.rmi.RmiInventory end_getInventory(Ice.AsyncResult r__)
                    {
                        IceInternal.OutgoingAsync outAsync__ = IceInternal.OutgoingAsync.check(r__, this, __getInventory_name);
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
                            es.upm.fi.rmi.RmiInventory ret__;
                            IceInternal.BasicStream is__ = outAsync__.startReadParams();
                            ret__ = null;
                            ret__ = es.upm.fi.rmi.RmiInventory.read__(is__, ret__);
                            outAsync__.endReadParams();
                            return ret__;
                        }
                        finally
                        {
                            outAsync__.cacheMessageBuffers();
                        }
                    }

                    private Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_getInventory> begin_getInventory(_System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        checkAsyncTwowayOnly__(__getInventory_name);
                        IceInternal.TwowayOutgoingAsync<es.upm.fi.rmi.Callback_InventoryService_getInventory> result__ =  getTwowayOutgoingAsync<es.upm.fi.rmi.Callback_InventoryService_getInventory>(__getInventory_name, getInventory_completed__, cookie__);
                        if(cb__ != null)
                        {
                            result__.whenCompletedWithAsyncCallback(cb__);
                        }
                        try
                        {
                            result__.prepare(__getInventory_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                            result__.writeEmptyParams();
                            result__.invoke();
                        }
                        catch(Ice.Exception ex__)
                        {
                            result__.abort(ex__);
                        }
                        return result__;
                    }

                    private void getInventory_completed__(Ice.AsyncResult r__, es.upm.fi.rmi.Callback_InventoryService_getInventory cb__, Ice.ExceptionCallback excb__)
                    {
                        es.upm.fi.rmi.RmiInventory ret__;
                        try
                        {
                            ret__ = end_getInventory(r__);
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

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_updateItem> begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem)
                    {
                        return begin_updateItem(rmiItem, null, false, false, null, null);
                    }

                    public Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_updateItem> begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__)
                    {
                        return begin_updateItem(rmiItem, ctx__, true, false, null, null);
                    }

                    public Ice.AsyncResult begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_updateItem(rmiItem, null, false, false, cb__, cookie__);
                    }

                    public Ice.AsyncResult begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        return begin_updateItem(rmiItem, ctx__, true, false, cb__, cookie__);
                    }

                    private const string __updateItem_name = "updateItem";

                    public void end_updateItem(Ice.AsyncResult r__)
                    {
                        end__(r__, __updateItem_name);
                    }

                    private Ice.AsyncResult<es.upm.fi.rmi.Callback_InventoryService_updateItem> begin_updateItem(es.upm.fi.rmi.RmiItem rmiItem, _System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
                    {
                        IceInternal.OnewayOutgoingAsync<es.upm.fi.rmi.Callback_InventoryService_updateItem> result__ = getOnewayOutgoingAsync<es.upm.fi.rmi.Callback_InventoryService_updateItem>(__updateItem_name, updateItem_completed__, cookie__);
                        if(cb__ != null)
                        {
                            result__.whenCompletedWithAsyncCallback(cb__);
                        }
                        try
                        {
                            result__.prepare(__updateItem_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                            IceInternal.BasicStream os__ = result__.startWriteParams(Ice.FormatType.DefaultFormat);
                            rmiItem.write__(os__);
                            result__.endWriteParams();
                            result__.invoke();
                        }
                        catch(Ice.Exception ex__)
                        {
                            result__.abort(ex__);
                        }
                        return result__;
                    }

                    private void updateItem_completed__(es.upm.fi.rmi.Callback_InventoryService_updateItem cb__)
                    {
                        if(cb__ != null)
                        {
                            cb__();
                        }
                    }

                    #endregion

                    #region Checked and unchecked cast operations

                    public static InventoryServicePrx checkedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        InventoryServicePrx r = b as InventoryServicePrx;
                        if((r == null) && b.ice_isA(ice_staticId()))
                        {
                            InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static InventoryServicePrx checkedCast(Ice.ObjectPrx b, _System.Collections.Generic.Dictionary<string, string> ctx)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        InventoryServicePrx r = b as InventoryServicePrx;
                        if((r == null) && b.ice_isA(ice_staticId(), ctx))
                        {
                            InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static InventoryServicePrx checkedCast(Ice.ObjectPrx b, string f)
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
                                InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static InventoryServicePrx checkedCast(Ice.ObjectPrx b, string f, _System.Collections.Generic.Dictionary<string, string> ctx)
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
                                InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                                h.copyFrom__(bb);
                                return h;
                            }
                        }
                        catch(Ice.FacetNotExistException)
                        {
                        }
                        return null;
                    }

                    public static InventoryServicePrx uncheckedCast(Ice.ObjectPrx b)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        InventoryServicePrx r = b as InventoryServicePrx;
                        if(r == null)
                        {
                            InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                            h.copyFrom__(b);
                            r = h;
                        }
                        return r;
                    }

                    public static InventoryServicePrx uncheckedCast(Ice.ObjectPrx b, string f)
                    {
                        if(b == null)
                        {
                            return null;
                        }
                        Ice.ObjectPrx bb = b.ice_facet(f);
                        InventoryServicePrxHelper h = new InventoryServicePrxHelper();
                        h.copyFrom__(bb);
                        return h;
                    }

                    public static readonly string[] ids__ =
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::InventoryService"
                    };

                    public static string ice_staticId()
                    {
                        return ids__[1];
                    }

                    #endregion

                    #region Marshaling support

                    public static void write__(IceInternal.BasicStream os__, InventoryServicePrx v__)
                    {
                        os__.writeProxy(v__);
                    }

                    public static InventoryServicePrx read__(IceInternal.BasicStream is__)
                    {
                        Ice.ObjectPrx proxy = is__.readProxy();
                        if(proxy != null)
                        {
                            InventoryServicePrxHelper result = new InventoryServicePrxHelper();
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
                public abstract class InventoryServiceDisp_ : Ice.ObjectImpl, InventoryService
                {
                    #region Slice operations

                    public es.upm.fi.rmi.RmiInventory getInventory()
                    {
                        return getInventory(Ice.ObjectImpl.defaultCurrent);
                    }

                    public abstract es.upm.fi.rmi.RmiInventory getInventory(Ice.Current current__);

                    public void updateItem(es.upm.fi.rmi.RmiItem rmiItem)
                    {
                        updateItem(rmiItem, Ice.ObjectImpl.defaultCurrent);
                    }

                    public abstract void updateItem(es.upm.fi.rmi.RmiItem rmiItem, Ice.Current current__);

                    #endregion

                    #region Slice type-related members

                    public static new readonly string[] ids__ = 
                    {
                        "::Ice::Object",
                        "::es::upm::fi::rmi::InventoryService"
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
                    public static Ice.DispatchStatus getInventory___(InventoryService obj__, IceInternal.Incoming inS__, Ice.Current current__)
                    {
                        Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
                        inS__.readEmptyParams();
                        es.upm.fi.rmi.RmiInventory ret__ = obj__.getInventory(current__);
                        IceInternal.BasicStream os__ = inS__.startWriteParams__(Ice.FormatType.DefaultFormat);
                        es.upm.fi.rmi.RmiInventory.write__(os__, ret__);
                        inS__.endWriteParams__(true);
                        return Ice.DispatchStatus.DispatchOK;
                    }

                    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
                    public static Ice.DispatchStatus updateItem___(InventoryService obj__, IceInternal.Incoming inS__, Ice.Current current__)
                    {
                        Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
                        IceInternal.BasicStream is__ = inS__.startReadParams();
                        es.upm.fi.rmi.RmiItem rmiItem;
                        rmiItem = new es.upm.fi.rmi.RmiItem();
                        rmiItem.read__(is__);
                        inS__.endReadParams();
                        obj__.updateItem(rmiItem, current__);
                        inS__.writeEmptyParams__();
                        return Ice.DispatchStatus.DispatchOK;
                    }

                    private static string[] all__ =
                    {
                        "getInventory",
                        "ice_id",
                        "ice_ids",
                        "ice_isA",
                        "ice_ping",
                        "updateItem"
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
                                return getInventory___(this, inS__, current__);
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
                                return updateItem___(this, inS__, current__);
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