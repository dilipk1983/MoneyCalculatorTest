# MoneyCalculatorTest

easyJet Interview Assessment 

# NOTE : 
	**Build scripts are created for 62-bit system with visual studio 2019 community edition
	If your configuration is different then please change path for MSBuild.exe and VSTest.Console.exe in "Build Test Run.cmd" file**

Money - Candidate Instructions 
------------------------------

Provide a working solution containing implementations of the following interfaces, With tests demonstrating there correctness

Use whatever tools and .net version you have available 

```csharp 
	///<summary>
	/// An amount of money in a particular currency.
	///</summary>
	interface IMoney
	{
		/// <summary>
		/// The amount of money this instance represents. 
		/// </summary>
		decimal Amount { get; }
		
		/// <summary>
		/// The ISO currency code of this instance.
		/// <summary>
		string Currency { get; }
	
	}

	/// <summary>
	/// Some fun things to do with money.
	/// <summary>
	interface IMoneyCalculator
	{
		/// <summary>
		/// Find the largest amount of Money.
		/// </summary>
		/// <returns>The <see cref="IMoney"/> instance having the largest amount.</returns>
		/// <exception cref="ArgumantException"> All monies are not in the same currency.</exception>
		/// <example>{GBP10, GBP20, GBP50} => {GBP50}</example> 
		/// <example>{GBP10, GBP20, EUR50} => exception<example> 
		IMoney Max(IEnumerable<IMoney> monies);
		
		
		/// <summary>
		/// Return one <see cref="Imoney"/> per currency with the sum of all monies of the same currency.
		/// </summary>
		/// <example> {GBP10, GBP20, GBP50} => {GBP80}</example>
		/// <example> {GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
		/// <example> {GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
		IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
		
	}


