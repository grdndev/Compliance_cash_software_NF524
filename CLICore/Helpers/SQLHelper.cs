using System;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CLICore.Helpers
{
    public class SQLHelper
    {
        public SQLHelper()
        {
        }
        public static DataTable ExecuteRequeteR(string pRequeteStr, string pConnection)
        {
            // ***********************************************************************
            // *                          Execute une requete SQL                    *
            // * ENTREE :                                                            *
            // *    pRequete : Requete SQL                                           *
            // *    pConnection : Chaine de connection à la base de donnée           *
            // * SORTIE :                                                            *
            // *    Un datatable rempli par la requete                               * 
            // ***********************************************************************
            Microsoft.Data.SqlClient.SqlConnection vCnn = new Microsoft.Data.SqlClient.SqlConnection(pConnection);
            DataSet vDataSet = new DataSet("DatasetTempo");
            DataTable vDatatable;
            Microsoft.Data.SqlClient.SqlDataAdapter SqlDataAdapter = new Microsoft.Data.SqlClient.SqlDataAdapter(pRequeteStr, vCnn);
            SqlDataAdapter.Fill(vDataSet, "Recherche");
            vDatatable = vDataSet.Tables["Recherche"];
            vDataSet.Dispose();
            vCnn.Close();
            return vDatatable;
        }

    }
}

