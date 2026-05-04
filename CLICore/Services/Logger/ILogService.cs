using System;
using CLICore.Models;

namespace CLICore.Services.Logger
{
	public interface ILogService
	{
		// NF525 — interface réduite : Phase 1 du devis interdit toute fonction
		// d'effacement des logs (EraseAll / EraseFrom / EraseFromTo / EraseExceptLast
		// définitivement supprimés). Seuls l'ajout (LogEvent) et la lecture (GetAll)
		// restent autorisés.

		Task<bool> LogEvent(string LogEntry, string LogDetail, long LogAssociatedRecordId = 0, string LogAssociatedRecordType = "", string LogType = "");
		Task<List<TLog>> GetAll();
	}
}
