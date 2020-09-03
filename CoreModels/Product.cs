namespace BusinessRulesEngine.CoreModels
{
	/// <summary>
	/// Lowest level of Abstraction for Product
	/// </summary>
	public abstract class Product
	{
		public string ProductDescription { get; private set; }
		public string ImagePath { get; private set; }
		public double UnitPrice { get; private set; }

		/// <summary>
		/// Set the Description
		/// </summary>
		/// <param name="productDescription"></param>
		public Product(string productDescription)
		{
			this.ProductDescription = productDescription;
		}
	}
}
