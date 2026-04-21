using System;
using CLIPrestashopConnector.Models;

namespace CLIPrestashopConnector.Services.Push
{
	public interface IPushService
	{
		
		Task<bool> Notify(string Title, string Detail);

    }
}