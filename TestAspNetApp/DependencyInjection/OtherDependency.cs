namespace TestAspNetApp
{
	public class OtherDependency : IOtherDependency
	{
		public string ExampleMethod (string name)
		{
			return $"OtherDependency tested by {name}";
		}
	}
}