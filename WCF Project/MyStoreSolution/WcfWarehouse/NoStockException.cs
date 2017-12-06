using System;
using System.ServiceModel;

namespace WcfWarehouse
{
    public class NoStockException : FaultException
    {
    }
}