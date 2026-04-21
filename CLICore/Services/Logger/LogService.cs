using System;
using System.Runtime.CompilerServices;
using CLICore.Data;
using CLICore.Models;
using Microsoft.EntityFrameworkCore.Update;


namespace CLICore.Services.Logger
{
	public class LogService : ILogService
	{

        private readonly CLIContext _cliContext;

        public LogService(CLIContext cliContext)
		{
            _cliContext = cliContext;
        }

        async public Task<bool> LogEvent(string LogEntry, string LogDetail,long LogAssociatedRecordId= 0, string LogAssociatedRecordType = "", string LogType = "")
        {
            // insertion dans T_Log
            var TLog = new TLog() { LogDateTime = DateTime.Now, LogEntry = LogEntry, LogDetail = LogDetail,LogAssociatedRecordId=LogAssociatedRecordId,LogAssociatedRecordType=LogAssociatedRecordType,LogType=LogType,LogVersionApi=System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() };
// debug print assemblyinfo version
Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                await _cliContext.TLogs.AddAsync(TLog);
                await _cliContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }

        async public Task<bool> EraseAll()
        {
            try
            {
                foreach (var item in _cliContext.TLogs)
                {
                    _cliContext.Remove(item);
                }
                await _cliContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        async public Task<bool> EraseFrom(DateTime fromDateTime)
        {
            var toDelete = from t in _cliContext.TLogs where t.LogDateTime >= fromDateTime select t;

            try
            {
                foreach (var item in toDelete)
                {
                    _cliContext.Remove(item);
                }
                await _cliContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        async public Task<bool> EraseFromTo(DateTime fromDateTime, DateTime toDateTime)
        {
            var toDelete = from t in _cliContext.TLogs where t.LogDateTime >= fromDateTime && t.LogDateTime<= toDateTime select t;

            try
            {
                foreach (var item in toDelete)
                {
                    _cliContext.Remove(item);
                }
                await _cliContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

// Function qui permet supprimer les logs d'un type d'enregistrement sauf les deux derniers logs 
async public Task<bool> EraseExceptLast(int number)
        {
// On récupère tous les logs
// On les trie par type d'enregistrement et par date
var AllLogs = from t in _cliContext.TLogs
              orderby t.LogAssociatedRecordId, t.LogAssociatedRecordType, t.LogDateTime descending
              select t;
var i=0;
long? LogAssociatedRecordId=0;
string? LogAssociatedRecordType="";
foreach (var item in AllLogs)
{
    if (item.LogAssociatedRecordId != LogAssociatedRecordId || item.LogAssociatedRecordType != LogAssociatedRecordType)
    {
        i =1;
        LogAssociatedRecordId = item.LogAssociatedRecordId;
        LogAssociatedRecordType = item.LogAssociatedRecordType;
    }
    else
    {
        i++;
    }
    if (i > number)
    {
        _cliContext.Remove(item);
    }
}
try
{
    await _cliContext.SaveChangesAsync();

    return true;
}
catch (Exception ex)
{
    return false;
}
}




        

        async public Task<List<TLog>> GetAll()
        {
            try
            {
                
                await _cliContext.SaveChangesAsync();

                return _cliContext.TLogs.OrderByDescending(c=> c.LogDateTime).ToList();
            }
            catch (Exception ex)
            {
                return new List<TLog>() ;
            }
        }
    }
}

