using Gtk;
using System;
using System.Data;
using System.Collections.Generic;

public struct DataTableParameter
{
    public DataTableParameter(string name, string value)
    {
        this.name = name;
        this.value = value;
        this.comparator = "=";
    }
    public DataTableParameter(string name, string value, string comparator)
    {
        this.name = name;
        this.value = value;
        this.comparator = comparator;
    }
    public string name;
    public string value;
    public string comparator;
}

namespace SistemaEyS.Database.Connection
{
    public abstract class DataTableTemplate
    {
        public Type[] gTypes;
        public ListStore Model;
        public ConnectionBase conn;
        public string DBTable;

        public DataTableTemplate()
        {
            this.gTypes = new Type[1]
            {
                typeof(string)
            };
            this.Model = new ListStore(this.gTypes);
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
                QueryParameters += $"`{parameters[i].name}`,";
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
            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
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

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
        }
        public virtual void DeleteFrom(ConnectionBase conn, DataTableParameter id)
        {
            string Query = $"DELETE FROM {this.DBTable} WHERE " +
                $"{id.name} = {id.value};";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
        }

        public virtual bool DoesExist(string op = "AND", params DataTableParameter[] data)
        {
            List<string> QuerySelect = new List<string>();
            List<string> QueryValues = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                QuerySelect.Add($"`{data[i].name}`");
                QueryValues.Add($"`{data[i].name}` {data[i].comparator} {data[i].value}");
            }

            string QueryS = String.Join<string>(", ", QuerySelect);
            string QueryV = String.Join<string>($" {op} ", QueryValues);

            string Query = $"SELECT {QueryS} FROM {this.DBTable} WHERE " +
                    $"{QueryV};";
            bool value = false;

            IDataReader idr = null;
            try
            {
                idr = conn.Read(CommandType.Text, Query);
                value = idr.Read();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.SetPosition(WindowPosition.Mouse);
                ms.Run();
                ms.Destroy();
            }
            finally
            {
                if (idr != null && !idr.IsClosed)
                {
                    idr.Close();
                }
            }
            return value;
        }
        public ListStore Search(string op = "AND", params DataTableParameter[] data)
        {
            ListStore store = new ListStore(
                this.gTypes
            );

            List<string> QueryValues = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                QueryValues.Add($"`{data[i].name}` {data[i].comparator} {data[i].value}");
            }

            string QueryV = String.Join<string>($" {op} ", QueryValues);

            IDataReader idr = null;
            string Query = $"SELECT * FROM {this.DBTable} WHERE " +
                    $"{QueryV};";
            try
            {
                idr = conn.Read(CommandType.Text, Query);
                if (!idr.Read()) return null;

                string[] arr = new string[this.gTypes.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    string value = idr.IsDBNull(i) ? "" : idr.GetValue(i).ToString();
                    arr[i] = value;
                }

                store.AppendValues(arr);
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.SetPosition(WindowPosition.Mouse);
                ms.Run();
                ms.Destroy();
            }
            finally
            {
                if (idr != null && !idr.IsClosed)
                {
                    idr.Close();
                }
            }
            return store;
        }
    }
}
