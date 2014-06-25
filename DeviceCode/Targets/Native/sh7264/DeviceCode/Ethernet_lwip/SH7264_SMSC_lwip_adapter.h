////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "tinyhal.h" 
#include "net_decl_lwip.h"
#include "lwip\dhcp.h"

#ifndef _SH7264_SMSC_LWIP_ADAPTER_H_1
#define _SH7264_SMSC_LWIP_ADAPTER_H_1 1

// Data Structures
struct SH7264_SMSC_LWIP_DRIVER_CONFIG
{
    GPIO_PIN            PHY_PD_GPIO_Pin;            // phy power down control
};

struct SH7264_SMSC_LWIP_Driver
{
    static int  Open   (   int           );
    static BOOL Close  (   void          );
    static BOOL Bind   (   void          );
};

//
// SH7264_SMSC_LWIP_ADAPTER
//////////////////////////////////////////////////////////////////////////////

#endif