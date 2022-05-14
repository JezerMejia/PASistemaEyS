using Gtk;
using System;
using System.Data;

public struct DataTableParameter
{
    public DataTableParameter(string name, string value)
    {
        this.name = name;
        this.value = value;
    }
    public string name;
    public string value;
}

namespace SistemaEyS.Database.Connection
{
    public abstract class DataTableTemplate
    {
        public ListStore Model;
        public ConnectionBase conn;
        public string DBTable;

        public DataTableTemplate()
        {
            this.Model = new ListStore(typeof(string));
        }

        public ListStore GetData()
        {
            this.UpdateModel();
            return this.Model;
        }

        public abstract void UpdateModel();

        public virtual void InsertInto(params DataTableParameter[] parameters)
        {
            string QueryParameters = "";
            string QueryValues = "";

            for (int i = 0; i < parameters.Length; i++)
            {
                QueryParameters += $"{parameters[i].name},";
                QueryValues += $"{parameters[i].value},";
            }
            if (QueryParameters.EndsWith(","))
                QueryParameters = QueryParameters.Remove(QueryParameters.Length - 1);
            if (QueryValues.EndsWith(","))
                QueryValues = QueryValues.Remove(QueryValues.Length - 1);

            string Query = $"INSERT INTO {this.DBTable} (" +
                    $"{QueryParameters}" +
                    ") " +
                    "VALUES (" +
                    $"{QueryValues}" +
                    ");";
            this.conn.Execute(CommandType.Text, Query);
        }
        public virtual void UpdateSet(params DataTableParameter[] parameters)
        {
            string QueryValues = "";

            for (int i = 1; i < parameters.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parameters[i].name)) continue;
                QueryValues += $"{parameters[i].name} = {parameters[i].value},";
            }
            if (QueryValues.EndsWith(","))
                QueryValues = QueryValues.Remove(QueryValues.Length - 1);

            string Query = $"UPDATE {this.DBTable} SET {QueryValues} " +
                $"WHERE {parameters[0].name} = {parameters[0].value};";
            this.conn.Execute(CommandType.Text, Query);
        }
        public virtual void DeleteFrom(ConnectionBase conn, DataTableParameter id)
        {
            string Query = $"DELETE FROM {this.DBTable} WHERE " +
                $"{id.name} = {id.value};";

            this.conn.Execute(CommandType.Text, Query);
        }
    }
}
