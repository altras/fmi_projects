using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Product catalog business tier component
/// </summary>
public static class CatalogAccess
{
    static CatalogAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // Retrieve the list of departments 
    public static DataTable GetDepartments()
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetDepartments";
        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}
