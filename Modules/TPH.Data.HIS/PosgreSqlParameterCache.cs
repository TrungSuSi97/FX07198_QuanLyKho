﻿namespace TPH.Data.HIS
{
    using System;
    using System.Collections;
    using System.Data;
    using Npgsql;

    public sealed class PosgreNpgsqlParameterCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlHelperParameterCache()"
        private PosgreNpgsqlParameterCache() { }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Resolve at run time the appropriate set of NpgsqlParameters for a stored procedure
        /// </summary>
        /// <param name="connection">A valid NpgsqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
        /// <returns>The parameter array discovered.</returns>
        private static NpgsqlParameter[] DiscoverSpParameterSet(NpgsqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(spName)) throw new ArgumentNullException("spName");

            NpgsqlCommand cmd = new NpgsqlCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            NpgsqlCommandBuilder.DeriveParameters(cmd);
            connection.Close();

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            NpgsqlParameter[] discoveredParameters = new NpgsqlParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            foreach (NpgsqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }

            return discoveredParameters;
        }

        /// <summary>
        /// Deep copy of cached NpgsqlParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static NpgsqlParameter[] CloneParameters(NpgsqlParameter[] originalParameters)
        {
            NpgsqlParameter[] clonedParameters = new NpgsqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (NpgsqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params NpgsqlParameter[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("connectionString");
            if (string.IsNullOrWhiteSpace(commandText)) throw new ArgumentNullException("commandText");

            var hashKey = string.Format("{0}:{1}", connectionString, commandText);

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static NpgsqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("connectionString");
            if (string.IsNullOrWhiteSpace(commandText)) throw new ArgumentNullException("commandText");

            var hashKey = string.Format("{0}:{1}", connectionString, commandText);

            NpgsqlParameter[] cachedParameters = paramCache[hashKey] as NpgsqlParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of NpgsqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of NpgsqlParameters</returns>
        public static NpgsqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// <summary>
        /// Retrieves the set of NpgsqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a NpgsqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of NpgsqlParameters</returns>
        public static NpgsqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("connectionString");
            if (string.IsNullOrWhiteSpace(spName)) throw new ArgumentNullException("spName");

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of NpgsqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid NpgsqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of NpgsqlParameters</returns>
        internal static NpgsqlParameter[] GetSpParameterSet(NpgsqlConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// Retrieves the set of NpgsqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid NpgsqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of NpgsqlParameters</returns>
        internal static NpgsqlParameter[] GetSpParameterSet(NpgsqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (NpgsqlConnection clonedConnection = (NpgsqlConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of NpgsqlParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="connection">A valid NpgsqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of NpgsqlParameters</returns>
        private static NpgsqlParameter[] GetSpParameterSetInternal(NpgsqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (string.IsNullOrWhiteSpace(spName)) throw new ArgumentNullException("spName");

            string hashKey = string.Format("{0}:{1}{2}", connection.ConnectionString, spName,
                (includeReturnValueParameter ? ":include ReturnValue Parameter" : ""));
            NpgsqlParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as NpgsqlParameter[];
            if (cachedParameters == null)
            {
                NpgsqlParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions

    }
}