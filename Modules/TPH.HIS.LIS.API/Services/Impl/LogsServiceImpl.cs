
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TPH.HIS.WebAPI.Models.Logs;
using TPH.HIS.WebAPI.DataAccess;
using TPH.HIS.WebAPI.Extensions;
using TPH.HIS.WebAPI.Models;
using System.Data;
using TPH.Common.Converter;
using TPH.HIS.WebAPI.DataAccess.Impl;
using TPH.HIS.WebAPI.Configs;

namespace TPH.LIS.API.Services.Impl
{
    public class LogsServiceImpl : ILogsService
    {

        private static readonly LogExtension LogExtension;
        private readonly ILogDataAccess _logDataAccess = new LogDataAccessImpl();

        public LogsServiceImpl()
        {
        }

        public BaseResult Insert(LogMessageModel message)
        {
            try
            {
                message.Ip = Client.Ip();
                Task.Factory.StartNew(() =>
                {
                    LogExtension.WriteInfo(message);
                });

                if (HisApiCommonConfigs.EnableLogsDb)
                {
                    return _logDataAccess.InsertHisTracking(message);
                }
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() =>
                {
                    LogExtension.WriteException(ex);
                });
            }

            return new BaseResult() { };
        }

        public LogsReponse Search(LogFilter filter)
        {
            var result = new LogsReponse()
            {
                Logs = new List<LogMessageModel>()
            };

            try
            {
                if (filter == null)
                {
                    return result;
                }

                if (HisApiCommonConfigs.EnableLogsDb)
                {
                    var logs = _logDataAccess.GetHisTracking(filter);

                    if (logs != null && logs.Rows.Count > 0)
                    {
                        foreach (DataRow item in logs.Rows)
                        {
                            //Action, InputMessage, OutputMessage, ErrorMessage, Username, IP
                            result.Logs.Add(new LogMessageModel()
                            {
                                MessageId = StringConverter.ToString(item["LogId"]),
                                Ip = StringConverter.ToString(item["IP"]),
                                InputMessage = StringConverter.ToString(item["InputMessage"]),
                                OutputMessage = StringConverter.ToString(item["OutputMessage"]),
                                ErrorMessage = StringConverter.ToString(item["ErrorMessage"]),
                                Username = StringConverter.ToString(item["Username"]),
                                LogDate = DateTimeConverter.ToDateTime(item["LogDate"]).ToString("dd/MM/yyyy HH:mm:ss")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public BaseResult Delete(string key)
        {
            try
            {
            }
            catch (Exception ex)
            {

            }

            return new BaseResult() { };
        }
    }
}