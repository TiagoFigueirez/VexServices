using System.Data;
using System.Data.Common;
using VexServices.Repository.GenericBd;

namespace VexServices.Repository.GenericDB
{
    public class GenericDataBase
    {
        public static DbCommand CreateCommand(string cmdText, CommandType cmmType, List<DbParameter> parameters)
        {
            var factory = DbProviderFactories.GetFactory(ConnectionBd.ProviderName);

            var conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionBd.ConnectionString;

            var comm = conn.CreateCommand();
            comm.CommandText = cmdText;
            comm.CommandType = cmmType;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    comm.Parameters.Add(param);
                }
            }

            return comm;
        }

        public static DbParameter CreateParameter(string nameParameter, DbType typeParameter, Object valueParamter)
        {
            var factory = DbProviderFactories.GetFactory(ConnectionBd.ProviderName);
            var param = factory.CreateParameter();

            if (param != null)
            {
                param.ParameterName = nameParameter;
                param.DbType = typeParameter;
                param.Value = valueParamter;
            }

            return param;
        }

        public Object ExecuteCommand(string cmdText, CommandType cmdType, List<DbParameter> parameters, TypeCommand typeCmd)
        {
            var command = CreateCommand(cmdText, cmdType, parameters);
            Object retorno = null;

            try
            {
                command.Connection.Open();

                switch (typeCmd)
                {
                    case TypeCommand.ExecuteNonQuery:
                        retorno = command.ExecuteNonQuery();
                        break;
                    case TypeCommand.ExecuteReader:
                        retorno = command.ExecuteReader();
                        break;
                    case TypeCommand.ExecuteScalar:
                        retorno = command.ExecuteScalar();
                        break;
                    case TypeCommand.ExecuteDataTable:
                        var table = new DataTable();

                        var reader = command.ExecuteReader();

                        table.Load(reader);
                        reader.Close();
                        retorno = table;
                        break;
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(typeCmd != TypeCommand.ExecuteReader)
                {
                    if(command.Connection.State == ConnectionState.Open)
                        command.Connection.Close();

                    command.Connection.Dispose();
                }
            }

            return retorno;
        }
    }

    public enum TypeCommand
    {
        ExecuteNonQuery
       ,ExecuteReader
       ,ExecuteScalar
       ,ExecuteDataTable
    }
}
