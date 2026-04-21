using System;
using CLICore.Models;

namespace CLICore.Services.Logger
{
	public interface ILogService
	{
		
		Task<bool> LogEvent(string LogEntry, string LogDetail,long LogAssociatedRecordId=0, string LogAssociatedRecordType="",string LogType="");
		Task<bool> EraseAll();
		Task<bool> EraseFrom(DateTime fromDateTime);
		Task<bool> EraseFromTo(DateTime fromDateTime, DateTime toDateTime);
		Task<List<TLog>> GetAll();
		Task<bool> EraseExceptLast(int number);

    }
}

