using System;
namespace CLIPrestashopConnector.Services.PrestashopErrorDecoder
{
	public interface IPrestashopErrorDecoderService
	{
		List<string>Decode(string input);
	}
}

