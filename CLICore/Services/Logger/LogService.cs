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

        async public Task<bool> LogEvent(string LogEntry, string LogDetail, long LogAssociatedRecordId = 0, string LogAssociatedRecordType = "", string LogType = "")
        {
            // insertion dans T_Log
            var TLog = new TLog()
            {
                LogDateTime = DateTime.Now,
                LogEntry = LogEntry,
                LogDetail = LogDetail,
                LogAssociatedRecordId = LogAssociatedRecordId,
                LogAssociatedRecordType = LogAssociatedRecordType,
                LogType = LogType,
                LogVersionApi = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!.ToString()
            };

            try
            {
                await _cliContext.TLogs.AddAsync(TLog);
                await _cliContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // NF525 — méthodes EraseAll / EraseFrom / EraseFromTo / EraseExceptLast
        // supprimées définitivement (Phase 1 du devis : interdiction de purge des logs).
        // Aucun effacement n'est autorisé, même par un administrateur.

        async public Task<List<TLog>> GetAll()
        {
            try
            {
                await _cliContext.SaveChangesAsync();
                return _cliContext.TLogs.OrderByDescending(c => c.LogDateTime).ToList();
            }
            catch (Exception)
            {
                return new List<TLog>();
            }
        }
    }
}
