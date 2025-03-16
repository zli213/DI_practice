using System;
namespace ConfigService
{
	public interface IConfigService
	{
		public string GetValue(string name);
	}
}

