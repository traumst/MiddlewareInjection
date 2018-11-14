namespace TestAspNetApp
{
	public class ExampleDependency : IExampleDependency
	{
		public string ExampleMethod (string name)
		{
			return $"ExampleDependency tested by {name}";
		}
	}
}